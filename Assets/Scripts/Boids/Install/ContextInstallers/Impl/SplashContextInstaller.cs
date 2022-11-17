using Boids.Context.Contexts;
using Boids.Context.Contexts.Impl;
using Boids.Install.InstallImpl.World.LifeCycle;
using Boids.World;
using Impl.Worlds.Splash;

namespace Boids.Install.ContextInstallers.Impl
{
    public class SplashContextInstaller : IContextInstaller
    {
        private readonly WorldLifeCycleFactory _worldLifeCycleFactory;

        public SplashContextInstaller(WorldLifeCycleFactory worldLifeCycleFactory)
        {
            _worldLifeCycleFactory = worldLifeCycleFactory;
        } 
        
        public IContext Install()
        {
            return new SplashContext(CreateWorld());
        }

        private IWorld CreateWorld()
        {
            return new SplashWorld(_worldLifeCycleFactory.Create());
        }
    }
}