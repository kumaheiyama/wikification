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
        public ICollection<ContentPageDto> GetContentPages()
        {
            return _pageBusiness.GetAllContentPages();
        }

        [HttpPut("[action]")]
        public void PageRead(ContentPageDto page, UserDto user)
        {
            //Award XP, notify
            //(Award badge, notify)
            //(Award level, notify)
            //Notify
        }

        [HttpPost("[action]")]
        public void AddPage(AddContentPageRequestDto request)
        {
            _pageBusiness.AddPage(request);
        }
    }
}
