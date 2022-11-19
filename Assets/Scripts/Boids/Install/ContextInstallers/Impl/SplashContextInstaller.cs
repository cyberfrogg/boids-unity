using Boids.Context.Contexts;
using Boids.Context.Contexts.Impl;
using Boids.Install.InstallImpl.World.LifeCycle;
using Boids.Services;
using Boids.World;
using Impl.Worlds.Splash;

namespace Boids.Install.ContextInstallers.Impl
{
    public class SplashContextInstaller : IContextInstaller
    {
        private readonly WorldLifeCycleFactory _worldLifeCycleFactory;
        private readonly IServiceLocator _serviceLocator;

        public SplashContextInstaller(WorldLifeCycleFactory worldLifeCycleFactory, IServiceLocator serviceLocator)
        {
            _worldLifeCycleFactory = worldLifeCycleFactory;
            _serviceLocator = serviceLocator;
        } 
        
        public IContext Install()
        {
            return new SplashContext(CreateWorld(), _serviceLocator);
        }

        private IWorld CreateWorld()
        {
            return new SplashWorld(_worldLifeCycleFactory.Create(), _serviceLocator);
        }
    }
}