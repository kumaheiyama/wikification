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
    public class AchievementBusiness : IAchievementBusiness
    {
        public readonly MainContext _context;

        public AchievementBusiness(MainContext context)
        {
            _context = context;
        }

        public void AddBadge(AddBadgeRequestDto request)
        {
            var existingBadge = _context.Badges
                .FirstOrDefault(x => x.Name == request.Name);
            if (existingBadge == null)
            {
                var newBadge = new Badge();
                newBadge.Name = request.Name;
                newBadge.Description = request.Description;
                newBadge.SymbolUrl = request.SymbolUrl;
                newBadge.AwardedXp = request.AwardedXp;

                _context.Badges.Add(newBadge);
                _context.SaveChanges();
            }
        }

        public void AddLevel(AddLevelRequestDto request)
        {
            var existingLevel = _context.Levels
                .FirstOrDefault(x => x.Name == request.Name);
            if (existingLevel == null)
            {
                var newLevel = new Level();
                newLevel.Name = request.Name;
                newLevel.XpThreshold = request.XpThreshold;

                _context.Levels.Add(newLevel);
                _context.SaveChanges();
            }
        }

        public LevelDto GetAchievedLevel(int currentXp)
        {
            var level = _context.Levels
                .Where(x => x.XpThreshold <= currentXp)
                .OrderBy(x => x.XpThreshold)
                .LastOrDefault();

            if (level != null)
            {
                return new LevelDto
                {
                    Name = level.Name,
                    XpThreshold = level.XpThreshold
                };
            }
            return null;
        }

        public ICollection<BadgeDto> GetAllBadges()
        {
            var badges = _context.Badges
                .Select(x => new BadgeDto
                {
                    AwardedXp = x.AwardedXp,
                    Description = x.Description,
                    Name = x.Name,
                    SymbolUrl = x.SymbolUrl
                })
                .ToArray();
            return badges;
        }

        public ICollection<LevelDto> GetAllLevels()
        {
            var levels = _context.Levels
                .Select(x => new LevelDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    XpThreshold = x.XpThreshold
                })
                .ToArray();

            return levels;
        }

        public ICollection<BadgeDto> GetAwardedBadges()
        {
            throw new NotImplementedException();
        }

        public ICollection<BadgeDto> GetUnawardedBadges()
        {
            throw new NotImplementedException();
        }

        public void RemoveBadge(RemoveBadgeRequestDto request)
        {
            throw new NotImplementedException();
        }

        public void RemoveLevel(RemoveLevelRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
