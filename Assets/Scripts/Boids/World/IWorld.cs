using System;
using Boids.Services;
using Boids.World.LifeCycle;
using Boids.World.WorldAbstracts.Entity;

namespace Boids.World
{
    public interface IWorld
    {
        bool IsEnabled { get; set; }
        event Action<string> SwitchRequested;
        void RequestSwitch(string world);
        IServiceLocator ServiceLocator { get; }
        IWorldLifeCycle LifeCycle { get; }
        IWorldEntityCollection Entities { get; }
    }
}