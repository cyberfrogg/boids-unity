using System.Collections.Generic;
using Services.LifeCycle.Factory.Impl;
using Services.Logger.Impl;

namespace Services.ServiceLocator.Impl
{
    public class ServiceLocatorFactory : IServiceLocatorFactory
    {
        public IServiceLocator Create()
        {
            var services = new List<IService>()
            {
                new ConsoleLogger(),
                new LifeCycleFactoryService()
            };
            
            return new ServiceLocator(services.AsReadOnly());
        }
    }
}