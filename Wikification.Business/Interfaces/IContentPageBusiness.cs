﻿using System.Collections.Generic;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;

namespace Wikification.Business.Interfaces
{
    public interface IContentPageBusiness
    {
        ICollection<ContentPageDto> GetAllContentPages(string externalId);
        void AddPage(AddContentPageRequestDto request);
        void UpdatePage(UpdateContentPageRequestDto request);
        void AddCategory(AddCategoryRequestDto request);
        void RemoveCategory(RemoveCategoryRequestDto request);
    }
}
