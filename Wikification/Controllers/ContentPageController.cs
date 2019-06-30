using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;

namespace Wikification.Controllers
{
    [Route("api/[controller]")]
    public class ContentPageController : Controller
    {
        private readonly IContentPageBusiness _pageBusiness;

        public ContentPageController(IContentPageBusiness pageBusiness)
        {
            _pageBusiness = pageBusiness;
        }

        [HttpGet("[action]")]
        public ICollection<ContentPageDto> GetContentPages(string externalId)
        {
            return _pageBusiness.GetAllContentPages(externalId);
        }

        [HttpPut("[action]")]
        public void ReadPage(string systemExternalId, string pageExternalId, string userExternalId = null)
        {
        }

        [HttpPost("[action]")]
        public void SavePage([FromBody] SaveContentPageRequestDto request)
        {
            _pageBusiness.SavePage(request);
        }

        [HttpPost("[action]")]
        public string ParseContents([FromBody] string contents)
        {
            return _pageBusiness.ParseContents(contents);
        }
    }
}
