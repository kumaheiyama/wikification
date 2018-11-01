using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Dto.Response;

namespace Wikification.Business.Interfaces
{
    public interface IAchievementBusiness
    {
        void AddLevel(AddLevelRequestDto request);
        void AddBadge(AddBadgeRequestDto request);
        void RemoveLevel(RemoveLevelRequestDto request);
        void RemoveBadge(RemoveBadgeRequestDto request);
        ICollection<LevelDto> GetAllLevels(string externalId);
        ICollection<BadgeDto> GetAllBadges(string externalId);
        UserBadgeResponseDto GetAwardedBadges(string externalId);
        ICollection<BadgeDto> GetUnawardedBadges(string externalId);
        AchievedLevelResponseDto GetAchievedLevel(string externalId, int currentXp);
        BadgeDto GetBadge(string systemExternalId, string name);
    }
}
