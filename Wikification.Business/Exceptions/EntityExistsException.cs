using System;

namespace Wikification.Business.Exceptions
{
    public class EntityExistsException : ArgumentException
    {
        public EntityExistsException(string typeName, string message, string paramName = null) : base(message, paramName)
        {
            TypeName = typeName;
        }

        public string TypeName { get; private set; }
    }
}
