using Boids.Services;

namespace Boids.World.Services.UidGenerator
{
    public interface IUidGenerator : IService
    {
        int Next();
    }
}