using System.Collections.Generic;

namespace Boids.Services.Impl.SharedServices
{
    public class SharedServiceLocatorFactory : IServiceLocatorFactory
    {
        public IServiceLocator Create()
        {
            var services = new List<IService>()
            {
                
            };

            return new ServiceLocator(services);
        }
    }
}