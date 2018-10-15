using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Dto.Response;
using Wikification.Business.Exceptions;
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
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "AddBadgeRequestDto.SystemExternalId");
            }

            var existingBadge = _context.Badges
                .Where(x => x.SystemId == system.Id)
                .FirstOrDefault(x => x.Name == request.Name);
            if (existingBadge == null)
            {
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
        }

        public void AddLevel(AddLevelRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            var existingLevel = _context.Levels
                .FirstOrDefault(x => x.Name == request.Name);
            if (existingLevel == null)
            {
                var newLevel = new Level
                {
                    Name = request.Name,
                    XpThreshold = request.XpThreshold,
                    System = system
                };

                _context.Levels.Add(newLevel);
                _context.SaveChanges();
            }
        }

        public LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            var level = _context.Levels
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.XpThreshold <= currentXp)
                .OrderBy(x => x.XpThreshold)
                .LastOrDefault();

            if (level != null)
            {
                return new LevelDto
                {
                    Id = level.Id,
                    Name = level.Name,
                    XpThreshold = level.XpThreshold,
                };
            }
            return null;
        }

        public ICollection<BadgeDto> GetAllBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

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
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            var levels = _context.Levels
                .Where(x => x.SystemId == system.Id)
                .Select(x => new LevelDto
                {
                    Id = x.Id,
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
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

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

        public ICollection<BadgeDto> GetUnawardedBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

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
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "RemoveBadgeRequestDto.SystemExternalId");
            }

            var existingBadge = _context.Badges
                .Where(x => x.SystemId == system.Id)
                .FirstOrDefault(x => x.Id == request.BadgeId);
            if (existingBadge == null)
            {
                throw new EntityNotFoundException("Badge", $"Badge '{request.BadgeId}' was not found.", "RemoveBadgeRequestDto.BadgeId");
            }

            var pages = _context.ContentPages
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.BadgeId == request.BadgeId)
                .ToList();
            pages.ForEach(x => x.BadgeId = null);

            var categories = _context.Categories
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.BadgeId == request.BadgeId)
                .ToList();
            categories.ForEach(x => x.BadgeId = null);

            var users = _context.Users
                .Include(x => x.EarnedBadges)
                .Where(x => x.SystemId == system.Id)
                .Where(x => x.EarnedBadges.Select(y => y.BadgeId).Contains(request.BadgeId))
                .ToList();
            foreach (var user in users)
            {
                var badges = user.EarnedBadges
                    .Where(x => x.BadgeId == request.BadgeId)
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
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "RemoveLevelRequestDto.SystemExternalId");
            }

            var existingLevel = _context.Levels
                .Where(x => x.SystemId == system.Id)
                .FirstOrDefault(x => x.Id == request.LevelId);
            if (existingLevel == null)
            {
                throw new EntityNotFoundException("Level", $"Level '{request.LevelId}' was not found.", "RemoveLevelRequestDto.LevelId");
            }

            _context.Levels
                .Remove(existingLevel);
            _context.SaveChanges();
        }
    }
}
