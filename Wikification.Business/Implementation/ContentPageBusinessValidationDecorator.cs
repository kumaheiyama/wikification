﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
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

        public override void SavePage(SaveContentPageRequestDto request)
        {
            var system = _context.Systems
                .Include(x => x.Pages)
                .AsNoTracking()
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "CreateContentPageDto.SystemExternalId");
            }

            base.SavePage(request);
        }

        public override ICollection<ContentPageDto> GetAllContentPages(string externalId)
        {
            if (string.IsNullOrEmpty(externalId)) { return new List<ContentPageDto>(); }
            return base.GetAllContentPages(externalId);
        }

        public override void AddCategory(AddCategoryRequestDto request)
        {
            var system = _context.Systems
                .AsNoTracking()
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "AddCategoryRequestDto.SystemExternalId");
            }
            if (request.Badge != null && request.SystemExternalId != request.Badge.SystemExternalId)
            {
                throw new SystemNotFoundException(request.Badge.SystemExternalId, $"External Id '{request.Badge.SystemExternalId}' is not valid.", "AddCategoryRequestDto.Badge.SystemExternalId");
            }

            base.AddCategory(request);
        }
        public override void RemoveCategory(RemoveCategoryRequestDto request)
        {
            var system = _context.Systems
                .AsNoTracking()
                .FirstOrDefault(x => x.ExternalId == request.SystemExternalId);
            if (system == null)
            {
                throw new SystemNotFoundException(request.SystemExternalId, $"External Id '{request.SystemExternalId}' is not valid.", "RemoveCategoryRequestDto.SystemExternalId");
            }

            base.RemoveCategory(request);
        }
    }
}
