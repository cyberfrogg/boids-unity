using Boids.World.LifeCycle;

namespace Boids.World
{
    public interface IWorld
    {
        bool IsEnabled { get; set; }
        IWorldLifeCycle LifeCycle { get; }
    }
}