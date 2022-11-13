﻿using System.Collections.Generic;
using Services.Controllers.Linker.Impl;
using Services.Controllers.Spawner.Impl;
using Services.Input.Impl;
using Services.LifeCycle.Factory.Impl;
using Services.Logger.Impl;
using Services.Raycast.Impl;
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

            var uidGenerator = new UidGenerator.Impl.UidGenerator();
            var controllerLinker = new ControllerLinker();
            
            var services = new List<IService>()
            {
                new ConsoleLogger(),
                settingsLocator,
                new LifeCycleFactoryService(),
                uidGenerator,
                controllerLinker,
                new ControllerPrefabSpawner(settingsLocator, controllerLinker, uidGenerator),
                new ControllerSpawner(controllerLinker, uidGenerator),
                new SceneProvider(settingsLocator),
                new SceneLoader(),
                new InputService(),
                new RayCastService()
            };
            
            return new ServiceLocator(services.AsReadOnly());
        }
    }
}