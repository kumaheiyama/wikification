using System;
using System.Collections.Generic;
using System.Text;

namespace Wikification.Business.Exceptions
{
    public class SystemNotFoundException : ArgumentException
    {
        public SystemNotFoundException(string externalId, string message, string paramName = null) : base(message, paramName)
        {
            ExternalId = externalId;
        }

        public string ExternalId { get; private set; }
    }
}
