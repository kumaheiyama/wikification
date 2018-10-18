﻿using Microsoft.EntityFrameworkCore;
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
            var contentPage = new ContentPage
            {
                Title = request.Title
            };
            var edition = new Edition
            {
                AwardedXp = request.AwardedXp,
                Contents = request.Contents,
                EditionDescription = string.Empty
            };
            contentPage.AddEdition(edition);

            _context.ContentPages.Add(contentPage);
            _context.SaveChanges();
        }

        public ICollection<ContentPageDto> GetAllContentPages()
        {
            var contentPages = _context.ContentPages
                .Include(x => x.Badge)
                .Include(x => x.Editions)
                .Include(x => x.Categories)
                .ThenInclude(cat => cat.Category)
                .ThenInclude(cat => cat.Badge)
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
                            AwardedXp = y.Category.CalculatedAwardedXp(),
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
                .AsNoTracking()
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            _achievementBusiness.AddBadge(request.Badge);
            var badge = _context.Badges
                .AsNoTracking()
                .Where(x => x.System == system)
                .FirstOrDefault(x => x.Name == request.Badge.Name);
            var category = new Category
            {
                AwardedXp = request.AwardedXp,
                Name = request.Name
            };
            category.SetBadge(badge);

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void RemoveCategory(RemoveCategoryRequestDto request)
        {
            //TODO constraints på tabell
            //TODO se över logik, måste ta bort från samtliga sidor och sedan från databasen
            //var contentPage = _context.ContentPages
            //    .Include(x => x.Categories)
            //    .SingleOrDefault(x => x.Id == request.ContentPageId);

            //var category = contentPage.Categories
            //   .FirstOrDefault(x => x.Category.Name == request.CategoryName);
            //if (category != null)
            //{
            //    contentPage.Categories.Remove(category);
            //}
            //_context.SaveChanges();
        }
    }
}
