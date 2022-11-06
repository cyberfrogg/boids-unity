using System.Collections.Generic;
using Services.Controllers.ControllerSpawner.Impl;
using Services.LifeCycle.Factory.Impl;
using Services.Logger.Impl;
using Services.Scenes.SceneLoader.Impl;
using Services.Scenes.SceneProvider.Impl;
using Settings;
using Settings.SettingsLocator.Impl;

namespace Services.ServiceLocator.Impl
{
    public class ServiceLocatorFactory : IServiceLocatorFactory
    {
        private readonly IReadOnlyCollection<ISettings> _settings;

        public ServiceLocatorFactory(IReadOnlyCollection<ISettings> settings)
        {
            _settings = settings;
        }
        
        public IServiceLocator Create()
        {
            var settingsLocator = new SettingsLocator(_settings);
            var services = new List<IService>()
            {
                new ConsoleLogger(),
                settingsLocator,
                new LifeCycleFactoryService(),
                new ControllerSpawner(),
                new SceneProvider(settingsLocator),
                new SceneLoader()
            };
            
            return new ServiceLocator(services.AsReadOnly());
        }
    }
}