using System;

namespace Exceptions
{
    [Serializable]
    public class ContextNotFoundException : Exception
    {
        public Type SearchType { get; }
        
        public ContextNotFoundException(Type type, string message) : base(message)
        {
            SearchType = type;
        }
    }
}