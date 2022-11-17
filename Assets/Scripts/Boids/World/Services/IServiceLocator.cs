using Boids.World.Services.ServicesList;

namespace Boids.World.Services
{
    public interface IServiceLocator
    {
        T GetService<T>() where T : IService;
    }
}