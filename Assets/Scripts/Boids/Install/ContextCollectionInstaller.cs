using System;
using System.Collections.Generic;
using Boids.Context;
using Boids.Context.Contexts;
using Boids.Context.Impl;
using Boids.Install.ContextInstallers;
using Boids.Install.ContextInstallers.Impl;
using Boids.Install.InstallImpl.World.LifeCycle;
using Boids.Install.Settings;

namespace Boids.Install
{
    public class ContextCollectionInstaller
    {
        private readonly ContextsInstallerSettings _settings;

        public ContextCollectionInstaller(ContextsInstallerSettings settings)
        {
            _settings = settings;
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
                        installers.Add(new SplashContextInstaller(worldLifeCycleFactory));
                        break;
                    case EContextType.Game:
                        installers.Add(new GameContextInstaller(worldLifeCycleFactory));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Installation of context {contextSettingsItem.Type} not implemented. Remove context from settings or implement installation");
                }
            }
            
            return installers;
        }
    }
}