using UnityEngine;

namespace Boids.World.LifeCycle.Impl
{
    public class WorldLifeCycleFactory
    {
        public IWorldLifeCycle Create()
        {
            var go = new GameObject()
            {
                name = nameof(WorldLifeCycle)
            };

            var lifeCycle = go.AddComponent<WorldLifeCycle>();
            lifeCycle.Initialize();
            Object.DontDestroyOnLoad(go);
            return lifeCycle;
        }
    }
}