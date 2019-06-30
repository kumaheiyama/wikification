using System;
using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data.Interfaces;

namespace Wikification.Business.Implementation
{
    public class ContentPageBusinessExceptionLoggingDecorator : ContentPageBusinessDecorator
    {
        private readonly ILogifier _log;

        public ContentPageBusinessExceptionLoggingDecorator(IContentPageBusiness inner, ILogifier log) : base(inner)
        {
            _log = log;
        }

        public override void SavePage(SaveContentPageRequestDto request)
        {
            try
            {
                base.SavePage(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override ICollection<ContentPageDto> GetAllContentPages(string externalId)
        {
            try
            {
                return base.GetAllContentPages(externalId);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override void AddCategory(AddCategoryRequestDto request)
        {
            try
            {
                base.AddCategory(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }
        public override void RemoveCategory(RemoveCategoryRequestDto request)
        {
            try
            {
                base.RemoveCategory(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override string ParseContents(string contents)
        {
            try
            {
                return base.ParseContents(contents);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
