using System;
using System.Collections.Generic;
using Boids.Context.Contexts;
using Boids.Services;
using Boids.Services.Impl.SharedServices.Logger.Impl;
using Boids.Services.Impl.SharedServices.SceneLoader.Impl;

namespace Boids.Install.Settings
{
    public class ContextServicesFactory
    {
        private readonly IReadOnlyCollection<IService> _gameServices;
        private readonly IReadOnlyCollection<IService> _splashServices;
        private readonly IReadOnlyCollection<IService> _sharedServices;
        
        public ContextServicesFactory()
        {
            _gameServices = new List<IService>()
            {

            };
            _splashServices = new List<IService>()
            {

            };
            _sharedServices = new List<IService>()
            {
                new SceneLoader(),
                new ConsoleLogger()
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