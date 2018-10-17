using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Exceptions;
using Wikification.Business.Interfaces;
using Wikification.Data;

namespace Wikification.Business.Implementation
{
    public class SystemBusinessValidationDecorator : SystemBusinessDecorator
    {
        private readonly MainContext _context;

        public SystemBusinessValidationDecorator(ISystemBusiness inner, MainContext context) : base(inner)
        {
            _context = context;
        }

        public override void AddNewSystem(CreateExternalSystemRequestDto request)
        {
            if (_context.Systems
                .AsNoTracking()
                .Any(x => x.ExternalId == request.ExternalId || x.Name == request.Name)) {
                throw new SystemExistsException($"System '{request.ExternalId}' already exists.", request.ExternalId, request.Name);
            }

            base.AddNewSystem(request);
        }

        public override void AddNewUser(AddUserRequestDto request)
        {
            var system = _context.Systems
                .AsNoTracking()
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "AddUserRequestDto.SystemExternalId");
            }

            base.AddNewUser(request);
        }

        public override void RemoveUser(RemoveUserRequestDto request)
        {
            var system = _context.Systems
                .AsNoTracking()
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "RemoveUserRequestDto.SystemExternalId");
            }

            base.RemoveUser(request);
        }

        public override long GetLatestEvent(string externalId)
        {
            var system = _context.Systems
                .AsNoTracking()
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "GetLatestEvent.ExternalId");
            }

            return base.GetLatestEvent(externalId);
        }

        public override ICollection<EventDto> GetEvents(string externalId, long startTimestamp, long endTimestamp = 0)
        {
            var system = _context.Systems
                .AsNoTracking()
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == externalId);
            if (system == null)
            {
                throw new SystemNotFoundException(externalId, $"External Id '{externalId}' is not valid.", "GetEvents.ExternalId");
            }

            return base.GetEvents(externalId, startTimestamp, endTimestamp);
        }
    }
}
