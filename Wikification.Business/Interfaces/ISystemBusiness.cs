using Wikification.Business.Dto.Request;

namespace Wikification.Business.Interfaces
{
    public interface ISystemBusiness
    {
        void AddNewSystem(CreateExternalSystemRequestDto externalSystem);
        void AddNewUser(AddUserRequestDto request);
        void RemoveUser(RemoveUserRequestDto request);
        long GetLatestEvent(string externalId);
    }
}
