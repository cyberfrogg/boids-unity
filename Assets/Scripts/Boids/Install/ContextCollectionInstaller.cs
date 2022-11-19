using System;
using System.Collections.Generic;
using Boids.Context;
using Boids.Context.Contexts;
using Boids.Context.Impl;
using Boids.Install.ContextInstallers;
using Boids.Install.ContextInstallers.Impl;
using Boids.Install.InstallImpl.World.LifeCycle;
using Boids.Install.Settings;
using Boids.Services;
using Boids.Services.Impl;
using Boids.Services.Impl.SharedServices.SettingsLocator;
using Boids.Services.Impl.SharedServices.SettingsLocator.Impl;

namespace Boids.Install
{
    public class ContextCollectionInstaller
    {
        private readonly ContextsInstallerSettings _settings;
        private readonly ContextServicesFactory _servicesFactory;

        public ContextCollectionInstaller(ContextsInstallerSettings settings)
        {
            _settings = settings;
            _servicesFactory = new ContextServicesFactory();
        }

        public IContextCollection InstallContextCollection()
        {
            var installers = GetInstallers();
            var contexts = new List<IContext>();

            foreach (var installer in installers)
            {
                contexts.Add(installer.Install());
            }
            
            return new ContextCollection(contexts);
        }

        private IReadOnlyCollection<IContextInstaller> GetInstallers()
        {
            var installers = new List<IContextInstaller>();
            var worldLifeCycleFactory = new WorldLifeCycleFactory();

            foreach (var contextSettingsItem in _settings.Contexts)
            {
                switch (contextSettingsItem.Type)
                {
                    case EContextType.Splash:
                        installers.Add(new SplashContextInstaller(worldLifeCycleFactory, GetContextServiceLocator(EContextType.Splash)));
                        break;
                    case EContextType.Game:
                        installers.Add(new GameContextInstaller(worldLifeCycleFactory, GetContextServiceLocator(EContextType.Game)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Installation of context {contextSettingsItem.Type} not implemented. Remove context from settings or implement installation");
                }
            }
            
            return installers;
        }

        private IServiceLocator GetContextServiceLocator(EContextType contextType)
        {
            var contextBasedSettings = _settings.SettingsContainer.GetContextSettings(contextType).Settings;
            var sharedSettings = _settings.SettingsContainer.SharedSettings.Settings;

            var settings = new List<ISettings>();
            settings.AddRange(contextBasedSettings);
            settings.AddRange(sharedSettings);
            var settingsLocator = new SettingsLocator(settings);

            var services = _servicesFactory.GetServices(contextType);
            services.Add(settingsLocator);
            var servicesLocator = new ServiceLocator(services);

            return servicesLocator;
        }
    }
}