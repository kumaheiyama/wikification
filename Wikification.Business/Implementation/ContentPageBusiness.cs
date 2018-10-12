using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Datastructure;

namespace Wikification.Business.Implementation
{
    public class ContentPageBusiness : IContentPageBusiness
    {
        private readonly MainContext _context;

        public ContentPageBusiness(MainContext context)
        {
            _context = context;
        }

        public void CreateContentPage(CreateContentPageDto request)
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
            return new List<ContentPageDto>
            {
                new ContentPageDto
                {
                    Title = "title1",
                    Version = "0.1.0"
                }
            };

            var contentPages = _context.ContentPages
                .Select(x => new ContentPageDto
                {
                    Badges = x.Badges
                        .Select(y => new BadgeDto
                        {
                            AwardedXp = y.CalculatedAwardedXp(),
                            Description = y.Description,
                            Name = y.Name,
                            SymbolUrl = y.SymbolUrl
                        })
                        .ToList(),
                    Categories = x.Categories
                        .Select(y => new CategoryDto
                        {
                            AwardedXp = y.CalculatedAwardedXp(),
                            Badge = y.Badge != null ?
                                new BadgeDto
                                {
                                    AwardedXp = y.Badge.CalculatedAwardedXp(),
                                    Description = y.Badge.Description,
                                    Name = y.Badge.Name,
                                    SymbolUrl = y.Badge.SymbolUrl
                                }
                                : null,
                            Name = y.Name
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
            //Borde istället lägga till ny badge i egen modul och söka upp den?
            var badge = request.Badge != null
                ? new Badge
                {
                    AwardedXp = request.Badge.AwardedXp,
                    Description = request.Badge.Description,
                    Name = request.Badge.Name,
                    SymbolUrl = request.Badge.SymbolUrl
                }
                : null;
            var category = new Category
            {
                AwardedXp = request.AwardedXp,
                Badge = badge,
                Name = request.CategoryName
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void RemoveCategory(RemoveCategoryRequestDto request)
        {
            //TODO constraints på tabell
            var contentPage = _context.ContentPages
                .Include(x => x.Categories)
                .SingleOrDefault(x => x.Id == request.ContentPageId);

            var category = contentPage.Categories
               .FirstOrDefault(x => x.Name == request.CategoryName);
            if (category != null)
            {
                contentPage.Categories.Remove(category);
            }
            _context.SaveChanges();
        }
    }
}
