using System;
using Worlds.Bundle;

namespace Worlds.Abstracts
{
    public interface IModel
    {
        event Action<IModel> Changed;
        public int Uid { get; set; }
        public EWorldBundleTag Tag { get; set; }
    }
}