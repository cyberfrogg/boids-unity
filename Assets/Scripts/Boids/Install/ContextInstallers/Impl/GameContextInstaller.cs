using Boids.Context.Contexts;
using Boids.Context.Contexts.Impl;
using Boids.Install.InstallImpl.World.LifeCycle;
using Boids.World;
using Impl.Worlds.Game;

namespace Boids.Install.ContextInstallers.Impl
{
    public class GameContextInstaller : IContextInstaller
    {
        private readonly WorldLifeCycleFactory _worldLifeCycleFactory;

        public GameContextInstaller(WorldLifeCycleFactory worldLifeCycleFactory)
        {
            _worldLifeCycleFactory = worldLifeCycleFactory;
        } 
        
        public IContext Install()
        {
            return new GameContext(CreateWorld());
        }

        private IWorld CreateWorld()
        {
            return new GameWorld(_worldLifeCycleFactory.Create());
        }
    }
}