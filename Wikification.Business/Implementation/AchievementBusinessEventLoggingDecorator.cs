using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Dto.Response;
using Wikification.Business.Exceptions;
using Wikification.Business.Interfaces;
using Wikification.Data;

namespace Wikification.Business.Implementation
{
    public class AchievementBusinessEventLoggingDecorator : AchievementBusinessDecorator
    {
        private readonly MainContext _context;

        public AchievementBusinessEventLoggingDecorator(IAchievementBusiness inner, MainContext context) : base(inner)
        {
            _context = context;
        }

        public override void AddBadge(AddBadgeRequestDto request)
        {
            base.AddBadge(request);

            //Log event
        }

        public override void AddLevel(AddLevelRequestDto request)
        {
            base.AddLevel(request);

            //Log event
        }

        public override void RemoveBadge(RemoveBadgeRequestDto request)
        {
            base.RemoveBadge(request);

            //Log event
        }

        public override void RemoveLevel(RemoveLevelRequestDto request)
        {
            base.RemoveLevel(request);

            //Log event
        }
    }
}
