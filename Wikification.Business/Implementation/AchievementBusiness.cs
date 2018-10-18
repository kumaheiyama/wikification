using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Dto.Response;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Datastructure;

namespace Wikification.Business.Implementation
{
    public class AchievementBusiness : IAchievementBusiness
    {
        public readonly MainContext _context;

        public AchievementBusiness(MainContext context)
        {
            _context = context;
        }

        public void AddBadge(AddBadgeRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var newBadge = new Badge
            {
                AwardedXp = request.AwardedXp,
                Description = request.Description,
                Name = request.Name,
                SymbolUrl = request.SymbolUrl,
                System = system
            };

            _context.Badges.Add(newBadge);
            _context.SaveChanges();
        }

        public void AddLevel(AddLevelRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var newLevel = new Level
            {
                Name = request.Name,
                XpThreshold = request.XpThreshold,
                System = system
            };

            _context.Levels.Add(newLevel);
            _context.SaveChanges();
        }

        public LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);

            var level = _context.Levels
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.XpThreshold <= currentXp)
                .OrderBy(x => x.XpThreshold)
                .LastOrDefault();
            if (level == null)
            {
                level = new Level
                {
                    Name = "Default",
                    System = system,
                    XpThreshold = 0
                };
                _context.Levels.Add(level);
                _context.SaveChanges();
            }

            return new LevelDto
            {
                Name = level.Name,
                XpThreshold = level.XpThreshold,
            };
        }

        public ICollection<BadgeDto> GetAllBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);

            var badges = _context.Badges
                .Where(x => x.SystemId == system.Id)
                .Select(x => new BadgeDto
                {
                    AwardedXp = x.AwardedXp,
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    SymbolUrl = x.SymbolUrl
                })
                .ToArray();
            return badges;
        }

        public ICollection<LevelDto> GetAllLevels(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);

            var levels = _context.Levels
                .Where(x => x.SystemId == system.Id)
                .Select(x => new LevelDto
                {
                    Name = x.Name,
                    XpThreshold = x.XpThreshold
                })
                .ToArray();

            return levels;
        }

        public UserBadgeResponseDto GetAwardedBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);

            var badges = _context.Badges
                .Include(x => x.Users)
                .ThenInclude(x => x.User)
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.Users.Count > 0)
                .ToList();

            var response = new UserBadgeResponseDto
            {
                Badges = new List<UserBadgeDto>()
            };
            foreach (var badge in badges)
            {
                foreach (var userBadge in badge.Users)
                {
                    response.Badges.Add(new UserBadgeDto
                    {
                        Badge = new BadgeDto
                        {
                            AwardedXp = badge.AwardedXp,
                            Description = badge.Description,
                            Id = badge.Id,
                            Name = badge.Name,
                            SymbolUrl = badge.SymbolUrl
                        },
                        User = new UserDto
                        {
                            CollectedXp = userBadge.User.CollectedXp(),
                            ExternalId = userBadge.User.ExternalId,
                            Username = userBadge.User.Username
                        }
                    });
                }
            }

            return response;
        }

        public BadgeDto GetBadge(string systemExternalId, string name)
        {
            var badge = _context.Badges
                .Where(x => x.System.ExternalId == systemExternalId)
                .Select(x => new BadgeDto
                {
                    AwardedXp = x.CalculatedAwardedXp(),
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    SymbolUrl = x.SymbolUrl
                })
                .FirstOrDefault(x => x.Name == name);
            return badge;
        }

        public ICollection<BadgeDto> GetUnawardedBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);

            var badges = _context.Badges
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.Users.Count == 0)
                .ToList();

            return badges.Select(x => new BadgeDto
            {
                AwardedXp = x.AwardedXp,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                SymbolUrl = x.SymbolUrl
            }).ToList();
        }

        public void RemoveBadge(RemoveBadgeRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var existingBadge = _context.Badges
                .Where(x => x.SystemId == system.Id)
                .FirstOrDefault(x => x.Name == request.BadgeName);

            var pages = _context.ContentPages
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.BadgeId == existingBadge.Id)
                .ToList();
            pages.ForEach(x => x.BadgeId = null);

            var categories = _context.Categories
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.BadgeId == existingBadge.Id)
                .ToList();
            categories.ForEach(x => x.BadgeId = null);

            var users = _context.Users
                .Include(x => x.EarnedBadges)
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.EarnedBadges.Select(y => y.BadgeId).Contains(existingBadge.Id))
                .ToList();
            foreach (var user in users)
            {
                var badges = user.EarnedBadges
                    .Where(x => x.BadgeId == existingBadge.Id)
                    .ToList();
                badges.ForEach(x => user.EarnedBadges.Remove(x));
            }

            _context.Badges
                .Remove(existingBadge);
            _context.SaveChanges();
        }

        public void RemoveLevel(RemoveLevelRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var existingLevel = _context.Levels
                .Where(x => x.SystemId == system.Id)
                .FirstOrDefault(x => x.Name == request.LevelName);

            _context.Levels
                .Remove(existingLevel);
            _context.SaveChanges();
        }
    }
}
