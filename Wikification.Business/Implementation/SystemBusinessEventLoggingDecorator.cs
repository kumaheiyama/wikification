using System;
using System.Linq;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Datastructure;
using Wikification.Data.Interfaces;

namespace Wikification.Business.Implementation
{
    public class SystemBusinessEventLoggingDecorator : SystemBusinessDecorator
    {
        private readonly MainContext _context;
        private readonly IEventLogger _logger;

        public SystemBusinessEventLoggingDecorator(ISystemBusiness inner, MainContext context, IEventLogger logger) : base(inner)
        {
            _context = context;
            _logger = logger;
        }

        public override void AddNewUser(AddUserRequestDto request)
        {
            base.AddNewUser(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"User '{request.Username}' was added!");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.UserAdded);

            _logger.LogEvent($"User '{request.Username}' was added!", ev);
        }

        public override void RemoveUser(RemoveUserRequestDto request)
        {
            base.RemoveUser(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"User '{request.Username}' was removed!");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.UserRemoved);

            _logger.LogEvent($"User '{request.Username}' was removed!", ev);
        }
    }
}
