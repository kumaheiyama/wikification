using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;

namespace Wikification.Business.Implementation
{
    public class ContentPageBusinessDecorator : IContentPageBusiness
    {
        private readonly IContentPageBusiness _inner;

        public ContentPageBusinessDecorator(IContentPageBusiness inner)
        {
            _inner = inner;
        }

        public virtual void AddPage(AddContentPageRequestDto request)
        {
            _inner.AddPage(request);
        }

        public virtual ICollection<ContentPageDto> GetAllContentPages()
        {
            return _inner.GetAllContentPages();
        }

        public virtual void AddCategory(AddCategoryRequestDto request)
        {
            _inner.AddCategory(request);
        }
        public virtual void RemoveCategory(RemoveCategoryRequestDto request)
        {
            _inner.RemoveCategory(request);
        }
    }
}
