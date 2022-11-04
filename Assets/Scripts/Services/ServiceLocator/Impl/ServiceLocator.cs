using System.Collections.Generic;
using System.Linq;
using Exceptions;

namespace Services.ServiceLocator.Impl
{
    public class ServiceLocator : IServiceLocator
    {
        private IReadOnlyCollection<IService> _services;

        public ServiceLocator(IReadOnlyCollection<IService> services)
        {
            _services = services;
        }
        
        public T GetService<T>() where T : IService
        {
            var foundServices = _services.OfType<T>();

            if (!foundServices.Any())
                throw new ServiceNotFoundException(typeof(T), $"Service {typeof(T).Name} not found");

            return foundServices.First();
        }
    }
}