﻿using Wikification.Business.Dto.Request;

namespace Wikification.Business.Interfaces
{
    public interface ISystemBusiness
    {
        void AddNewSystem(CreateExternalSystemRequestDto externalSystem);
    }
}
