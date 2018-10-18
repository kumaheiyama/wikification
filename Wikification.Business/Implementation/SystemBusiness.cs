using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
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
            var newExternalSystem = new ExternalSystem
            {
                CallbackUrl = request.CallbackUrl,
                ExternalId = request.ExternalId,
                Name = request.Name
            };

            //Add users
            var lowestLevel = _context.Levels
                .OrderBy(x => x.XpThreshold)
                .FirstOrDefault();
            if (lowestLevel == null)
            {
                var newDefaultLevel = new Level
                {
                    Name = "Default level",
                    System = newExternalSystem,
                    XpThreshold = 0
                };
                _context.Levels.Add(newDefaultLevel);
            }

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
                            Name = cat.Name,
                            System = newExternalSystem
                        };

                        if (badge == null && cat.Badge != null)
                        {
                            badge = new Badge
                            {
                                AwardedXp = cat.Badge.AwardedXp,
                                Description = cat.Badge.Description,
                                Name = cat.Badge.Name,
                                SymbolUrl = cat.Badge.SymbolUrl,
                                System = newExternalSystem
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

        public void AddNewUser(AddUserRequestDto request)
        {
            var newUser = new User();
            newUser.SetExternalId(request.ExternalId);
            newUser.SetUsername(request.Username);

            var system = _context.Systems
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var existingUser = system.Users
                .FirstOrDefault(x => x.ExternalId == request.ExternalId || x.Username == request.Username);

            system.Users.Add(newUser);
            _context.SaveChanges();
        }

        public long GetLatestEvent(string externalId)
        {
            var lastEvent = _context.Events
                .AsNoTracking()
                .OrderBy(x => x.Timestamp)
                .LastOrDefault(x => x.System.ExternalId == externalId);
            if (lastEvent == null) { return 0; }

            return lastEvent.Timestamp;
        }

        public void RemoveUser(RemoveUserRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var existingUser = _context.Users
                .Where(x => x.System == system)
                .FirstOrDefault(x => x.ExternalId == request.ExternalId || x.Username == request.Username);

            system.Users.Remove(existingUser);
            _context.SaveChanges();
        }

        public ICollection<EventDto> GetEvents(string externalId, long startTimestamp, long endTimestamp = 0)
        {
            var events = _context.Events
                .AsNoTracking()
                .Where(x => x.System.ExternalId == externalId)
                .Where(x => x.Timestamp >= startTimestamp);
            if (endTimestamp > 0 && endTimestamp > startTimestamp)
            {
                events = events
                    .Where(x => x.Timestamp <= endTimestamp);
            }

            var response = events
                .OrderBy(x => x.Timestamp)
                .Select(x => new EventDto
                {
                    Name = x.Name,
                    Timestamp = x.Timestamp,
                    Type = (EventDto.EventDtoType)x.Type
                })
                .ToArray();

            return response;
        }
    }
}
