﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Datastructure;

namespace Wikification.Business.Implementation
{
    public class ContentPageBusiness : IContentPageBusiness
    {
        private readonly MainContext _context;
        private readonly IAchievementBusiness _achievementBusiness;

        public ContentPageBusiness(MainContext context, IAchievementBusiness achievementBusiness)
        {
            _context = context;
            _achievementBusiness = achievementBusiness;
        }

        public void AddPage(AddContentPageRequestDto request)
        {
            var system = _context.Systems
                .Include(x => x.Pages)
                .First(x => x.ExternalId == request.ExternalId);

            var newPage = new ContentPage(request.Title);
            var newEdition = new Edition();
            newEdition.SetAwardedXp(request.AwardedXp);
            newEdition.SetContents(request.Contents);
            newEdition.SetEditionDescription(string.Empty);
            newPage.AddEdition(newEdition);
            newPage.SetExternalId(request.ExternalId);

            system.Pages.Add(newPage);
            _context.SaveChanges();
        }
        public void UpdatePage(UpdateContentPageRequestDto request)
        {
            var system = _context.Systems
                .Include(x => x.Pages)
                .ThenInclude(x => x.Editions)
                .Include(x => x.Categories)
                .First(x => x.ExternalId == request.SystemExternalId);
            var contentPage = system.Pages
                .Where(x => x.System == system)
                .First(x => x.ExternalId == request.ExternalId);

            var latestEdition = contentPage.LatestEdition();

            var newEdition = new Edition(latestEdition.Version);
            newEdition.SetContents(request.Contents);
            newEdition.SetEditionDescription(request.EditionDescription);
            newEdition.SetAwardedXp(latestEdition.CalculatedAwardedXp());

            var versionUpdate = (Edition.VersionUpdate)request.Version;
            newEdition.IncreaseVersion(versionUpdate);

            if (request.Categories != null)
            {
                foreach (var category in request.Categories)
                {
                    if (!contentPage.Categories.Any(x => x.Category.Name == category.Name))
                    {
                        var newCategory = new Category(category.Name);

                        if (category.Badge != null) {
                            var badge = system.Badges
                                .Where(x => x.SystemId == system.Id)
                                .FirstOrDefault(x => x.Name == category.Badge.Name);
                            newCategory.SetBadge(badge);
                        }

                        contentPage.AddCategory(newCategory);
                    }
                }
            }

            contentPage.AddEdition(newEdition);
            _context.SaveChanges();
        }

        public ICollection<ContentPageDto> GetAllContentPages(string externalId)
        {
            var system = _context.Systems
                .Include(x => x.Badges)
                .Include(x => x.Pages)
                .ThenInclude(x => x.Editions)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Pages)
                .First(x => x.ExternalId == externalId);

            var contentPages = system.Pages
                .Select(x => new ContentPageDto
                {
                    Badge = x.Badge != null
                        ? new BadgeDto
                        {
                            AwardedXp = x.Badge.CalculatedAwardedXp(),
                            Description = x.Badge.Description,
                            Name = x.Badge.Name,
                            SymbolUrl = x.Badge.SymbolUrl
                        }
                        : new BadgeDto(),
                    Categories = x.Categories
                        .Select(y => new CategoryDto
                        {
                            Badge = y.Category.Badge != null ?
                                new BadgeDto
                                {
                                    AwardedXp = y.Category.Badge.CalculatedAwardedXp(),
                                    Description = y.Category.Badge.Description,
                                    Name = y.Category.Badge.Name,
                                    SymbolUrl = y.Category.Badge.SymbolUrl
                                }
                                : null,
                            Name = y.Category.Name
                        })
                        .ToList(),
                    Contents = x.LatestEdition().Contents,
                    Title = x.Title,
                    Version = x.LatestEdition().Version.ToString()
                })
                .ToList();

            return contentPages;
        }

        public void AddCategory(AddCategoryRequestDto request)
        {
            var system = _context.Systems
                .Include(x => x.Badges)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            _achievementBusiness.AddBadge(request.Badge);
            var badge = system.Badges
                .FirstOrDefault(x => x.Name == request.Badge.Name);
            var category = new Category(request.Name, badge)
            {
                System = system
            };

            system.Categories.Add(category);
            _context.SaveChanges();
        }

        public void RemoveCategory(RemoveCategoryRequestDto request)
        {
            var system = _context.Systems
                .Include(x => x.Pages)
                .ThenInclude(x => x.Categories)
                .First(x => x.ExternalId == request.SystemExternalId);

            var contentPage = system.Pages
                .First(x => x.ExternalId == request.ContentPageExternalId);

            var category = contentPage.Categories
                .First(x => x.Category.Name == request.CategoryName);

            contentPage.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
