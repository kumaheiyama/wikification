using Microsoft.EntityFrameworkCore;
using System.Linq;
using Wikification.Business.Dto.Request;
using Wikification.Business.Exceptions;
using Wikification.Business.Interfaces;
using Wikification.Data;

namespace Wikification.Business.Implementation
{
    public class ContentPageBusinessValidationDecorator : ContentPageBusinessDecorator
    {
        private readonly MainContext _context;

        public ContentPageBusinessValidationDecorator(IContentPageBusiness inner, MainContext context) : base(inner)
        {
            _context = context;
        }

        public override void AddPage(AddContentPageRequestDto request)
        {
            var system = _context.Systems
                .AsNoTracking()
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "CreateContentPageDto.SystemExternalId");
            }

            base.AddPage(request);
        }

        //public override ICollection<ContentPageDto> GetAllContentPages()
        //{
        //    return base.GetAllContentPages();
        //}

        public override void AddCategory(AddCategoryRequestDto request)
        {
            var system = _context.Systems
                .AsNoTracking()
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "AddCategoryRequestDto.SystemExternalId");
            }

            base.AddCategory(request);
        }
        public override void RemoveCategory(RemoveCategoryRequestDto request)
        {
            var system = _context.Systems
                .AsNoTracking()
                .Include(x => x.Users)
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "RemoveCategoryRequestDto.SystemExternalId");
            }

            base.RemoveCategory(request);
        }
    }
}
