using Boids.Services;
using Boids.Services.Impl.SharedServices.Logger;
using Boids.Services.Impl.SharedServices.SceneLoader;
using Boids.World;
using Boids.World.LifeCycle;
using Boids.World.WorldAbstracts.Entity;
using Boids.World.WorldAbstracts.Entity.Impl;

namespace Impl.Worlds.Game
{
    public class GameWorld : IWorld
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILogger _logger;
        
        private bool _isEnabled;

        public GameWorld(IWorldLifeCycle worldLifeCycle, IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            _sceneLoader = ServiceLocator.GetService<ISceneLoader>();
            _logger = ServiceLocator.GetService<ILogger>();
            
            LifeCycle = worldLifeCycle;
            Entities = new WorldEntityCollection();
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
            _logger.Log("Game context enabled");
        }

        private void OnDisable()
        {
            
        }
    }
}
