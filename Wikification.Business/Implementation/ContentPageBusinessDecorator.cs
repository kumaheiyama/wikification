using System.Collections.Generic;
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

        public virtual void SavePage(SaveContentPageRequestDto request)
        {
            _inner.SavePage(request);
        }

        public virtual ICollection<ContentPageDto> GetAllContentPages(string externalId)
        {
            return _inner.GetAllContentPages(externalId);
        }

        public virtual void AddCategory(AddCategoryRequestDto request)
        {
            _inner.AddCategory(request);
        }
        public virtual void RemoveCategory(RemoveCategoryRequestDto request)
        {
            _inner.RemoveCategory(request);
        }

        public virtual string ParseContents(string contents)
        {
            return _inner.ParseContents(contents);
        }
    }
}
