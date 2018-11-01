using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;

namespace Wikification.Business.Interfaces
{
    public interface ISystemBusiness
    {
        void AddNewSystem(CreateExternalSystemRequestDto externalSystem);
        void AddNewUser(AddUserRequestDto request);
        void RemoveUser(RemoveUserRequestDto request);
        long GetLatestEvent(string externalId);
        ICollection<EventDto> GetEvents(string externalId, long startTimestamp, long endTimestamp = 0);
    }
}
