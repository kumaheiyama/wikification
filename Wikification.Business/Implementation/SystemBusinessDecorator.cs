using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;

namespace Wikification.Business.Implementation
{
    public class SystemBusinessDecorator : ISystemBusiness
    {
        private readonly ISystemBusiness _inner;

        public SystemBusinessDecorator(ISystemBusiness inner)
        {
            _inner = inner;
        }

        public virtual void AddNewSystem(CreateExternalSystemRequestDto request)
        {
            _inner.AddNewSystem(request);
        }

        public virtual void AddNewUser(AddUserRequestDto request)
        {
            _inner.AddNewUser(request);
        }

        public virtual long GetLatestEvent(string externalId)
        {
            return _inner.GetLatestEvent(externalId);
        }

        public virtual void RemoveUser(RemoveUserRequestDto request)
        {
            _inner.RemoveUser(request);
        }

        public virtual ICollection<EventDto> GetEvents(string externalId, long startTimestamp, long endTimestamp = 0)
        {
            return _inner.GetEvents(externalId, startTimestamp, endTimestamp);
        }
    }
}
