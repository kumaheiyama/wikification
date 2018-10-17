using Microsoft.EntityFrameworkCore;
using System.Linq;
using Wikification.Business.Dto.Request;
using Wikification.Business.Exceptions;
using Wikification.Business.Interfaces;
using Wikification.Data;

namespace Wikification.Business.Implementation
{
    public class ContentPageBusinessEventLoggingDecorator : ContentPageBusinessDecorator
    {
        private readonly MainContext _context;

        public ContentPageBusinessEventLoggingDecorator(IContentPageBusiness inner, MainContext context) : base(inner)
        {
            _context = context;
        }

        public override void AddPage(AddContentPageRequestDto request)
        {
            base.AddPage(request);

            //Log event
        }

        public override void AddCategory(AddCategoryRequestDto request)
        {
            base.AddCategory(request);

            //Log event
        }

        public override void RemoveCategory(RemoveCategoryRequestDto request)
        {
            base.RemoveCategory(request);

            //Log event
        }
    }
}
