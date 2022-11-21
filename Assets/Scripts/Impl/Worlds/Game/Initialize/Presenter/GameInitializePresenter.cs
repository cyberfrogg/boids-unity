using Boids.MvpUtils;
using Boids.World;
using Impl.Worlds.Game.Services;

namespace Impl.Worlds.Game.Initialize.Presenter
{
    public class GameInitializePresenter : APresenter
    {
        private readonly IWorld _world;
        private readonly ISpecialGameWorldService _specialGameWorldService;
        
        public GameInitializePresenter(IWorld world)
        {
            _world = world;
            _specialGameWorldService = _world.ServiceLocator.GetService<ISpecialGameWorldService>();
        }

        public void Initialize()
        {
            _specialGameWorldService.Test();
        }
    }
}