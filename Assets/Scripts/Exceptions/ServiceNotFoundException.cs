using System;

namespace Exceptions
{
    [Serializable]
    public class ServiceNotFoundException : Exception
    {
        public Type SearchType { get; }
        
        public ServiceNotFoundException(Type type, string message) : base(message)
        {
            SearchType = type;
        }
    }
}