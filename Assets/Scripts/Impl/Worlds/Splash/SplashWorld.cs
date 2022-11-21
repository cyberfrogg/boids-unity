using System;
using Boids.Services;
using Boids.Services.Impl.SharedServices.Logger;
using Boids.World;
using Boids.World.LifeCycle;
using Boids.World.Services.WorldEntityFactoryService;
using Boids.World.WorldAbstracts.Entity;
using Boids.World.WorldAbstracts.Entity.Impl;
using Impl.Worlds.Splash.Initialize.Model;
using Impl.Worlds.Splash.Initialize.Presenter;
using Impl.Worlds.Splash.Initialize.View;

namespace Impl.Worlds.Splash
{
    public class SplashWorld : IWorld
    {
        private readonly IWorldEntityFactoryService _worldEntityFactoryService;
        private readonly ILogger _logger;
        private bool _isEnabled;
        
        public SplashWorld(IWorldLifeCycle worldLifeCycle, IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            _logger = ServiceLocator.GetService<ILogger>();
            _worldEntityFactoryService = ServiceLocator.GetService<IWorldEntityFactoryService>();
            
            LifeCycle = worldLifeCycle;
            Entities = new WorldEntityCollection();
        }

        public event Action<string> SwitchRequested;
        public void RequestSwitch(string world)
        {
            SwitchRequested?.Invoke(world);
        }
        public IServiceLocator ServiceLocator { get; }
        public IWorldLifeCycle LifeCycle { get; }
        public IWorldEntityCollection Entities { get; }

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
            
            Initialize();
        }

        private void OnDisable()
        {
            
        }

        private void Initialize()
        {
            var initializeEntity = _worldEntityFactoryService
                .CreateEmpty<
                    SplashInitializeModel,
                    SplashInitializeView,
                    SplashInitializePresenter
                >(this, new SplashInitializeModel());
            
            initializeEntity.Presenter.Initialize();
        }
    }
}