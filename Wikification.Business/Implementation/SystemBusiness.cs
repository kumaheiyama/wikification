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
            var newExternalSystem = new ExternalSystem(request.Name, request.ExternalId, request.CallbackUrl);

            //Add users
            var lowestLevel = newExternalSystem.Levels
                .OrderBy(x => x.XpThreshold)
                .FirstOrDefault();
            if (lowestLevel == null)
            {
                var newDefaultLevel = new Level("Default level", 0);

                newExternalSystem.Levels.Add(newDefaultLevel);
            }

            foreach (var user in request.Users)
            {
                var newUser = new User(user.Username, user.ExternalId);
                newUser.SetLevel(lowestLevel);
                newExternalSystem.AddUser(newUser);
            }

            //Add pages
            foreach (var page in request.Pages)
            {
                var newPage = new ContentPage(page.Title);
                var newEdition = new Edition(page.Contents, page.AwardedXp, "Initial");
                newPage.AddEdition(newEdition);

                //Add categories
                foreach (var category in page.Categories)
                {
                    var existingCategory = newExternalSystem.Categories.FirstOrDefault(x => x.Name == category.Name);
                    var badge = category.Badge != null
                        ? newExternalSystem.Badges.FirstOrDefault(x => x.Name == category.Badge.Name)
                        : null;

                    if (existingCategory == null)
                    {
                        var newCategory = new Category(category.Name);

                        if (badge == null && category.Badge != null)
                        {
                            badge = new Badge(category.Badge.Name, category.Badge.Description, category.Badge.SymbolUrl, category.Badge.AwardedXp);
                        }
                        newCategory.SetBadge(badge);
                        newPage.AddCategory(newCategory);
                    }
                    else
                    {
                        newPage.AddCategory(existingCategory);
                    }
                }

                newExternalSystem.AddPage(newPage);
            }

            _context.Systems.Add(newExternalSystem);
            _context.SaveChanges();
        }

        public void AddNewUser(AddUserRequestDto request)
        {
            var newUser = new User(request.Username, request.ExternalId);

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
            var existingUser = system.Users
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
