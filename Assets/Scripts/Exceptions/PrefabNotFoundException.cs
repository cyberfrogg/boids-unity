using System;

namespace Exceptions
{
    [Serializable]
    public class PrefabNotFoundException : Exception
    {
        public string SearchName { get; }
        
        public PrefabNotFoundException(string name, string message) : base(message)
        {
            SearchName = name;
        }
    }
}