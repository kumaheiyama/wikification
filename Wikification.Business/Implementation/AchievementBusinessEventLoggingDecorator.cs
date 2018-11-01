using System;
using System.Linq;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Datastructure;
using Wikification.Data.Interfaces;

namespace Wikification.Business.Implementation
{
    public class AchievementBusinessEventLoggingDecorator : AchievementBusinessDecorator
    {
        private readonly MainContext _context;
        private readonly IEventLogger _logger;

        public AchievementBusinessEventLoggingDecorator(IAchievementBusiness inner, MainContext context, IEventLogger logger) : base(inner)
        {
            _context = context;
            _logger = logger;
        }

        public override void AddBadge(AddBadgeRequestDto request)
        {
            base.AddBadge(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"Badge '{request.Name}' was added!");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.BadgeAdded);

            _logger.LogEvent($"Badge '{request.Name}' was added!", ev);
        }

        public override void AddLevel(AddLevelRequestDto request)
        {
            base.AddLevel(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"Level '{request.Name}' was added!");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.LevelAdded);

            _logger.LogEvent($"Level '{request.Name}' was added!", ev);
        }

        public override void RemoveBadge(RemoveBadgeRequestDto request)
        {
            base.RemoveBadge(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"Badge '{request.BadgeName}' was removed.");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.BadgeRemoved);

            _logger.LogEvent($"Badge '{request.BadgeName}' was removed.", ev);
        }

        public override void RemoveLevel(RemoveLevelRequestDto request)
        {
            base.RemoveLevel(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"Level '{request.LevelName}' was added!");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.LevelRemoved);

            _logger.LogEvent($"Level '{request.LevelName}' was added!", ev);
        }
    }
}
