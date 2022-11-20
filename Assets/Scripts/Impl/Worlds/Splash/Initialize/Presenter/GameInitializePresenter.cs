using Boids.MvpUtils;
using Boids.Services.Impl.SharedServices.Logger;
using Boids.World;
using Boids.World.LifeCycle;

namespace Impl.Worlds.Splash.Initialize.Presenter
{
    public class GameInitializePresenter : APresenter, IUpdateListener
    {
        private readonly IWorld _world;
        private readonly ILogger _logger;
        
        public GameInitializePresenter(IWorld world)
        {
            _world = world;
            _logger = _world.ServiceLocator.GetService<ILogger>();
            _world.LifeCycle.AddUpdateListener(this);
        }

        public void Update()
        {
            _logger.Log("Update!");
        }
    }
}