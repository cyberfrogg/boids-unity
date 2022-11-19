﻿using Boids.Services;
using Boids.Services.Impl.SharedServices.Logger;
using Boids.Services.Impl.SharedServices.SceneLoader;
using Boids.World;
using Boids.World.LifeCycle;

namespace Impl.Worlds.Splash
{
    public class SplashWorld : IWorld
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILogger _logger;
        private bool _isEnabled;
        
        public SplashWorld(IWorldLifeCycle worldLifeCycle, IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _logger = _serviceLocator.GetService<ILogger>();
            
            LifeCycle = worldLifeCycle;
        }
        
        public IWorldLifeCycle LifeCycle { get; }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                LifeCycle.IsEnabled = value;
                _isEnabled = value;

                if (_isEnabled)
                    OnEnable();
                else
                    OnDisable();
            }
        }

        private void OnEnable()
        {
            _logger.Log("Splash context enabled");
        }

        private void OnDisable()
        {
            
        }
    }
}