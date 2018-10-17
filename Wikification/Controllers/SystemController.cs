using Microsoft.AspNetCore.Mvc;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data.Interfaces;

namespace Wikification.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly ISystemBusiness _systemBusiness;
        private readonly ILogifier _log;

        public SystemController(ISystemBusiness systemBusiness, ILogifier log)
        {
            _systemBusiness = systemBusiness;
            _log = log;
        }

        [HttpPost("[action]")]
        public void AddExternalSystem([FromBody] CreateExternalSystemRequestDto request)
        {
            _log.LogError("testmeddelande2", new System.Exception("testmeddelande 3"));

            _systemBusiness.AddNewSystem(request);
        }

        [HttpPost("[action]")]
        public void AddUser([FromBody] AddUserRequestDto request)
        {
            _systemBusiness.AddNewUser(request);
        }

        [HttpPost("[action]")]
        public void RemoveUser([FromBody] RemoveUserRequestDto request)
        {
            _systemBusiness.RemoveUser(request);
        }

        [HttpGet("[action]")]
        public long LastEvent(string externalId)
        {
            return _systemBusiness.GetLatestEvent(externalId);
        }
    }
}
