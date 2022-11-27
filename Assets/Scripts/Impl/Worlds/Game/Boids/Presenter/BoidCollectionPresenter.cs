using Boids.MvpUtils;
using Boids.World;
using Boids.World.LifeCycle;
using Impl.Worlds.Game.Boids.Model;

namespace Impl.Worlds.Game.Boids.Presenter
{
    public class BoidCollectionPresenter : APresenter, IUpdateListener
    {
        private readonly IWorld _world;

        private BoidCollectionModel _model;

        public BoidCollectionPresenter(IWorld world)
        {
            _world = world;
        }
        
        public void Initialize()
        {
            _model = (BoidCollectionModel)Model;
        }

        public void Update()
        {
            _model.FramesCount.Value = _model.FramesCount.Value >= int.MaxValue ? 0 : _model.FramesCount.Value + 1;
        }
    }
}