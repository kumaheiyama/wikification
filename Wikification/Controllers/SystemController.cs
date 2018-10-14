using Microsoft.AspNetCore.Mvc;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;

namespace Wikification.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly ISystemBusiness _systemBusiness;

        public SystemController(ISystemBusiness systemBusiness)
        {
            _systemBusiness = systemBusiness;
        }

        [HttpPost("[action]")]
        public void AddExternalSystem([FromBody] CreateExternalSystemRequestDto request)
        {
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
    }
}
