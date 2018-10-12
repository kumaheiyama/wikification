using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wikification.Business;
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
        public ICollection<ContentPageDto> GetContentPages()
        {
            return _pageBusiness.GetAllContentPages();
        }
    }
}
