using System;
using System.Collections.Generic;
using Boids.Context.Contexts;
using Boids.Services;
using Boids.Services.Impl.SharedServices.Logger.Impl;
using Boids.Services.Impl.SharedServices.SceneLoader.Impl;
using Boids.Services.Impl.SharedServices.ScenePointer.Impl;
using Boids.World.Services.UidGenerator.Impl;
using Boids.World.Services.WorldEntityFactoryService.Impl;
using Boids.World.Services.WorldEntityLinker.Impl;
using Impl.Worlds.Game.Services.Boids.BoidsFactory.Impl;

namespace Boids.Install.Settings
{
    public class ContextServicesFactory
    {
        private readonly IReadOnlyCollection<IService> _gameServices;
        private readonly IReadOnlyCollection<IService> _splashServices;
        private readonly IReadOnlyCollection<IService> _sharedServices;
        
        public ContextServicesFactory()
        {
            var uidGenerator = new UidGenerator();
            var consoleLogger = new ConsoleLogger();
            var worldEntityLinker = new WorldEntityLinker();
            var worldEntityFactory = new WorldEntityFactoryService(uidGenerator, worldEntityLinker);
            
            _gameServices = new List<IService>()
            {
                new BoidsFactoryService(worldEntityFactory)
            };
            _splashServices = new List<IService>()
            {

            };
            _sharedServices = new List<IService>()
            {
                consoleLogger,
                uidGenerator,
                new SceneLoader(),
                worldEntityFactory,
                new WorldSceneObjectPointerService()
            };
        }

        public List<IService> GetServices(EContextType contextType)
        {
            var result = new List<IService>();
            
            switch (contextType)
            {
                case EContextType.Splash:
                    result.AddRange(_splashServices);
                    break;
                case EContextType.Game:
                    result.AddRange(_gameServices);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(contextType), contextType, null);
            }

            result.AddRange(_sharedServices);
            return result;
        }
    }
}