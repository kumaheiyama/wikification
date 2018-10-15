using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Dto.Response;
using Wikification.Business.Interfaces;

namespace Wikification.Business.Implementation
{
    public class AchievementBusinessDecorator : IAchievementBusiness
    {
        private readonly IAchievementBusiness _inner;

        public AchievementBusinessDecorator(IAchievementBusiness inner)
        {
            _inner = inner;
        }

        public virtual void AddBadge(AddBadgeRequestDto request)
        {
            _inner.AddBadge(request);
        }

        public virtual void AddLevel(AddLevelRequestDto request)
        {
            _inner.AddLevel(request);
        }

        public virtual LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            return _inner.GetAchievedLevel(externalId, currentXp);
        }

        public virtual ICollection<BadgeDto> GetAllBadges(string externalId)
        {
            return _inner.GetAllBadges(externalId);
        }

        public virtual ICollection<LevelDto> GetAllLevels(string externalId)
        {
            return _inner.GetAllLevels(externalId);
        }

        public virtual UserBadgeResponseDto GetAwardedBadges(string externalId)
        {
            return _inner.GetAwardedBadges(externalId);
        }

        public virtual ICollection<BadgeDto> GetUnawardedBadges(string externalId)
        {
            return _inner.GetUnawardedBadges(externalId);
        }

        public virtual void RemoveBadge(RemoveBadgeRequestDto request)
        {
            _inner.RemoveBadge(request);
        }

        public virtual void RemoveLevel(RemoveLevelRequestDto request)
        {
            _inner.RemoveLevel(request);
        }
    }
}
