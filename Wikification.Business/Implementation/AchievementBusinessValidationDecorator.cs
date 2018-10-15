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
    public class AchievementBusinessValidationDecorator : AchievementBusinessDecorator
    {
        private readonly MainContext _context;

        public AchievementBusinessValidationDecorator(IAchievementBusiness inner, MainContext context) : base(inner)
        {
            _context = context;
        }

        public override void AddBadge(AddBadgeRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "AddBadgeRequestDto.SystemExternalId");
            }

            base.AddBadge(request);
        }

        public override void AddLevel(AddLevelRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            base.AddLevel(request);
        }

        public override LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            return base.GetAchievedLevel(externalId, currentXp);
        }

        public override ICollection<BadgeDto> GetAllBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            return base.GetAllBadges(externalId);
        }

        public override ICollection<LevelDto> GetAllLevels(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            return GetAllLevels(externalId);
        }

        public override UserBadgeResponseDto GetAwardedBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            return base.GetAwardedBadges(externalId);
        }

        public override ICollection<BadgeDto> GetUnawardedBadges(string externalId)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "AddLevelRequestDto.SystemExternalId");
            }

            return base.GetUnawardedBadges(externalId);
        }

        public override void RemoveBadge(RemoveBadgeRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "RemoveBadgeRequestDto.SystemExternalId");
            }

            base.RemoveBadge(request);
        }

        public override void RemoveLevel(RemoveLevelRequestDto request)
        {
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "RemoveLevelRequestDto.SystemExternalId");
            }

            base.RemoveLevel(request);
        }
    }
}
