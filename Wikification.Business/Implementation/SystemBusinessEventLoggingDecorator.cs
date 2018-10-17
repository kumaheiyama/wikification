using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Exceptions;
using Wikification.Business.Interfaces;
using Wikification.Data;

namespace Wikification.Business.Implementation
{
    public class SystemBusinessEventLoggingDecorator : SystemBusinessDecorator
    {
        private readonly MainContext _context;

        public SystemBusinessEventLoggingDecorator(ISystemBusiness inner, MainContext context) : base(inner)
        {
            _context = context;
        }

        public override void AddNewUser(AddUserRequestDto request)
        {
            base.AddNewUser(request);

            //Log event
        }

        public override void RemoveUser(RemoveUserRequestDto request)
        {
            base.RemoveUser(request);

            //Log event
        }
    }
}
