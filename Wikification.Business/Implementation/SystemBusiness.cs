using System.Linq;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Datastructure;

namespace Wikification.Business.Implementation
{
    public class SystemBusiness : ISystemBusiness
    {
        private readonly MainContext _context;

        public SystemBusiness(MainContext context)
        {
            _context = context;
        }

        public void AddNewSystem(CreateExternalSystemRequestDto request)
        {
            if (_context.Systems.Any(x => x.ExternalId == request.ExternalId || x.Name == request.Name)) { return; }

            var newExternalSystem = new ExternalSystem
            {
                CallbackUrl = request.CallbackUrl,
                ExternalId = request.ExternalId,
                Name = request.Name
            };

            //Add users
            var lowestLevel = _context.Levels
                .OrderBy(x => x.XpThreshold)
                .First();
            foreach (var user in request.Users)
            {
                var newUser = new User();
                newUser.SetExternalId(user.ExternalId);
                newUser.SetUsername(user.Username);
                newUser.SetLevel(lowestLevel);
                newExternalSystem.AddUser(newUser);
            }

            //Add pages
            foreach (var page in request.Pages)
            {
                var newPage = new ContentPage
                {
                    Title = page.Title,
                    System = newExternalSystem,
                };
                newPage.AddEdition(new Edition
                {
                    AwardedXp = page.AwardedXp,
                    Contents = page.Contents,
                    EditionDescription = "Initial"
                });

                //Add categories
                foreach (var cat in page.Categories)
                {
                    var existingCat = _context.Categories.FirstOrDefault(x => x.Name == cat.Name);
                    var badge = cat.Badge != null
                        ? _context.Badges.FirstOrDefault(x => x.Name == cat.Badge.Name)
                        : null;

                    if (existingCat == null)
                    {
                        var newCat = new Category
                        {
                            AwardedXp = cat.AwardedXp,
                            Name = cat.Name
                        };

                        if (badge == null && cat.Badge != null)
                        {
                            badge = new Badge
                            {
                                AwardedXp = cat.Badge.AwardedXp,
                                Description = cat.Badge.Description,
                                Name = cat.Badge.Name,
                                SymbolUrl = cat.Badge.SymbolUrl
                            };
                        }
                        newCat.SetBadge(badge);
                        newPage.AddCategory(newCat);
                    }
                    else
                    {
                        newPage.AddCategory(existingCat);
                    }
                }

                newExternalSystem.AddPage(newPage);
            }

            _context.Systems.Add(newExternalSystem);
            _context.SaveChanges();
        }
    }
}
