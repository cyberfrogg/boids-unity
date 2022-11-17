using System;
using Worlds.Bundle;

namespace Exceptions
{
    [Serializable]
    public class UidWithTagNotFoundException : Exception
    {
        public override string Message { get; }

        public EWorldBundleTag SearchedTag { get; }
        
        public UidWithTagNotFoundException(EWorldBundleTag tag)
        {
            SearchedTag = tag;
            Message = $"Failed to get uid with tag: {tag}";
        }
    }
}