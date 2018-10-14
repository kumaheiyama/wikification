using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;

namespace Wikification.Business.Interfaces
{
    public interface IAchievementBusiness
    {
        void AddLevel(AddLevelRequestDto request);
        void AddBadge(AddBadgeRequestDto request);
        void RemoveLevel(RemoveLevelRequestDto request);
        void RemoveBadge(RemoveBadgeRequestDto request);
        ICollection<LevelDto> GetAllLevels();
        ICollection<BadgeDto> GetAllBadges();
        ICollection<BadgeDto> GetAwardedBadges();
        ICollection<BadgeDto> GetUnawardedBadges();
        LevelDto GetAchievedLevel(int currentXp);
    }
}
