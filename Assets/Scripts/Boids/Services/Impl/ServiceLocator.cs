using System.Collections.Generic;
using System.Linq;

namespace Boids.Services.Impl
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IReadOnlyCollection<IService> _services;

        public ServiceLocator(IReadOnlyCollection<IService> services)
        {
            _services = services;
        }
        
        public T GetService<T>() where T : IService
        {
            var foundServices = _services.OfType<T>().ToList();

            if (foundServices.Count == 0)
                throw new KeyNotFoundException($"Service {typeof(T).Name} not found");

            return foundServices[0];
        }
    }
}