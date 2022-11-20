using Boids.MvpUtils;
using Boids.World;

namespace Impl.Worlds.Splash.Initialize.Presenter
{
    public class GameInitializePresenter : APresenter
    {
        private readonly IWorld _world;
        
        public GameInitializePresenter(IWorld world)
        {
            _world = world;
        }

        public void Initialize()
        {
            _world.RequestSwitch("Game");
        }
    }
}