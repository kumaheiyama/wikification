using System;

namespace Wikification.Business.Exceptions
{
    public class EntityNotFoundException : ArgumentException
    {
        public EntityNotFoundException(string typeName, string message, string paramName = null) : base(message, paramName)
        {
            TypeName = typeName;
        }

        public string TypeName { get; private set; }
    }
}
