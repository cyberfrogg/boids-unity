using Boids.World;

namespace Boids.Context.Contexts
{
    public interface IContext
    {
        bool IsEnabled { get; set; }
        IWorld World { get; }
        EContextType Type { get; }
    }
}