using System;
using System.Linq;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Datastructure;
using Wikification.Data.Interfaces;

namespace Wikification.Business.Implementation
{
    public class ContentPageBusinessEventLoggingDecorator : ContentPageBusinessDecorator
    {
        private readonly MainContext _context;
        private readonly IEventLogger _logger;

        public ContentPageBusinessEventLoggingDecorator(IContentPageBusiness inner, MainContext context, IEventLogger logger) : base(inner)
        {
            _context = context;
            _logger = logger;
        }

        public override void SavePage(SaveContentPageRequestDto request)
        {
            base.SavePage(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"Edition '{request.Title}' was added!");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.EditionAdded);

            _logger.LogEvent($"Edition '{request.Title}' was added!", ev);
        }

        public override void AddCategory(AddCategoryRequestDto request)
        {
            base.AddCategory(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"Category '{request.Name}' was added!");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.EditionAdded);

            _logger.LogEvent($"Category '{request.Name}' was added!", ev);
        }

        public override void RemoveCategory(RemoveCategoryRequestDto request)
        {
            base.RemoveCategory(request);

            //Log event
            var system = _context.Systems
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            var ev = new Event
            {
                System = system
            };
            ev.SetName($"Category '{request.CategoryName}' was removed.");
            ev.SetTimestamp(DateTime.UtcNow);
            ev.SetType(EventType.CategoryRemoved);

            _logger.LogEvent($"Category '{request.CategoryName}' was removed.", ev);
        }
    }
}
