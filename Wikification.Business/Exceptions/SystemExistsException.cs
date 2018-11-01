using System;

namespace Wikification.Business.Exceptions
{
    public class SystemExistsException : ArgumentException
    {
        public SystemExistsException(string message, string externalId = null, string systemName = null) : base(message)
        {
            ExternalId = externalId;
            SystemName = systemName;
        }

        public string ExternalId { get; private set; }
        public string SystemName { get; private set; }
    }
}
