using Boids.Context.Contexts;
using Boids.Context.Contexts.Impl;
using Boids.Services;
using Boids.World;
using Boids.World.LifeCycle.Impl;
using Impl.Worlds.Game;

namespace Boids.Install.ContextInstallers.Impl
{
    public class GameContextInstaller : IContextInstaller
    {
        private readonly WorldLifeCycleFactory _worldLifeCycleFactory;
        private readonly IServiceLocator _serviceLocator;

        public GameContextInstaller(WorldLifeCycleFactory worldLifeCycleFactory, IServiceLocator serviceLocator)
        {
            _worldLifeCycleFactory = worldLifeCycleFactory;
            _serviceLocator = serviceLocator;
        } 
        
        public IContext Install()
        {
            return new GameContext(CreateWorld(), _serviceLocator);
        }

        private IWorld CreateWorld()
        {
            return new GameWorld(_worldLifeCycleFactory.Create(), _serviceLocator);
        }
    }
}