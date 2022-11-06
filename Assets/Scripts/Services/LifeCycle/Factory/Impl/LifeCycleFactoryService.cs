using Contexts.LifeCycle;
using Contexts.LifeCycle.Impl;
using UnityEngine;

namespace Services.LifeCycle.Factory.Impl
{
    public class LifeCycleFactoryService : ILifeCycleFactoryService
    {
        public IContextLifeCycle Create()
        {
            var instance = new GameObject();
            instance.name = nameof(DefaultContextLifeCycle);
            var lc = instance.AddComponent<DefaultContextLifeCycle>();
            lc.IsEnabled = false;
            lc.Initialize();
            return lc;
        }
    }
}