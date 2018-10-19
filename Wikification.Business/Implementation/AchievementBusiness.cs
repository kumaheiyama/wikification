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
                .Include(x => x.Badges)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var newBadge = new Badge(request.Name, request.Description, request.SymbolUrl, request.AwardedXp);

            system.Badges.Add(newBadge);
            _context.SaveChanges();
        }

        public void AddLevel(AddLevelRequestDto request)
        {
            var system = _context.Systems
                .Include(x => x.Levels)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var newLevel = new Level(request.Name, request.XpThreshold);

            system.Levels.Add(newLevel);
            _context.SaveChanges();
        }

        public LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            var system = _context.Systems
                .Include(x => x.Levels)
                .FirstOrDefault(x => x.ExternalId == externalId);

            var level = system.Levels
                .Where(x => x.XpThreshold <= currentXp)
                .OrderBy(x => x.XpThreshold)
                .LastOrDefault();
            if (level == null)
            {
                level = new Level("Default", 0)
                {
                    System = system
                };
                system.Levels.Add(level);
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
                .Include(x => x.Badges)
                .FirstOrDefault(x => x.ExternalId == externalId);

            var badges = system.Badges
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
                .Include(x => x.Levels)
                .FirstOrDefault(x => x.ExternalId == externalId);

            var levels = system.Levels
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
                .Include(x => x.Badges)
                .ThenInclude(x => x.Users)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.ExternalId == externalId);

            var badges = system.Badges
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
            var system = _context.Systems
                .Include(x => x.Badges)
                .First(x => x.ExternalId == systemExternalId);

            var badge = system.Badges
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
                .Include(x => x.Badges)
                .FirstOrDefault(x => x.ExternalId == externalId);

            var badges = system.Badges
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
                .Include(x => x.Badges)
                .Include(x => x.Pages)
                .Include(x => x.Categories)
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var existingBadge = system.Badges
                .FirstOrDefault(x => x.Name == request.BadgeName);

            var pages = system.Pages
                .Where(x => x.BadgeId == existingBadge.Id)
                .ToList();
            pages.ForEach(x => x.BadgeId = null);

            var categories = system.Categories
                .Where(x => x.BadgeId == existingBadge.Id)
                .ToList();
            categories.ForEach(x => x.BadgeId = null);

            var users = system.Users
                .Where(x => x.EarnedBadges.Select(y => y.BadgeId).Contains(existingBadge.Id))
                .ToList();
            foreach (var user in users)
            {
                var badges = user.EarnedBadges
                    .Where(x => x.BadgeId == existingBadge.Id)
                    .ToList();
                badges.ForEach(x => user.EarnedBadges.Remove(x));
            }

            system.Badges
                .Remove(existingBadge);
            _context.SaveChanges();
        }

        public void RemoveLevel(RemoveLevelRequestDto request)
        {
            var system = _context.Systems
                .Include(x => x.Levels)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);

            var existingLevel = system.Levels
                .FirstOrDefault(x => x.Name == request.LevelName);

            system.Levels
                .Remove(existingLevel);
            _context.SaveChanges();
        }
    }
}
