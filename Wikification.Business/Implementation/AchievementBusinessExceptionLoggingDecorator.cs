using System;
using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Dto.Response;
using Wikification.Business.Interfaces;
using Wikification.Data.Interfaces;

namespace Wikification.Business.Implementation
{
    public class AchievementBusinessExceptionLoggingDecorator : AchievementBusinessDecorator
    {
        private readonly ILogifier _log;

        public AchievementBusinessExceptionLoggingDecorator(IAchievementBusiness inner, ILogifier log) : base(inner)
        {
            _log = log;
        }

        public override void AddBadge(AddBadgeRequestDto request)
        {
            try
            {
                base.AddBadge(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override void AddLevel(AddLevelRequestDto request)
        {
            try
            {
                base.AddLevel(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            try
            {
                return base.GetAchievedLevel(externalId, currentXp);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override ICollection<BadgeDto> GetAllBadges(string externalId)
        {
            try
            {
                return base.GetAllBadges(externalId);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override ICollection<LevelDto> GetAllLevels(string externalId)
        {
            try
            {
                return base.GetAllLevels(externalId);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override UserBadgeResponseDto GetAwardedBadges(string externalId)
        {
            try
            {
                return base.GetAwardedBadges(externalId);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override ICollection<BadgeDto> GetUnawardedBadges(string externalId)
        {
            try
            {
                return base.GetUnawardedBadges(externalId);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override void RemoveBadge(RemoveBadgeRequestDto request)
        {
            try
            {
                base.RemoveBadge(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override void RemoveLevel(RemoveLevelRequestDto request)
        {
            try
            {
                base.RemoveLevel(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
