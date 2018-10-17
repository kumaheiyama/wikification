using System;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data.Interfaces;

namespace Wikification.Business.Implementation
{
    public class SystemBusinessExceptionLoggingDecorator : SystemBusinessDecorator
    {
        private readonly ILogifier _log;

        public SystemBusinessExceptionLoggingDecorator(ISystemBusiness inner, ILogifier log) : base(inner)
        {
            _log = log;
        }

        public override void AddNewSystem(CreateExternalSystemRequestDto request)
        {
            try
            {
                base.AddNewSystem(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override void AddNewUser(AddUserRequestDto request)
        {
            try
            {
                base.AddNewUser(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }

        public override void RemoveUser(RemoveUserRequestDto request)
        {
            try
            {
                base.RemoveUser(request);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
