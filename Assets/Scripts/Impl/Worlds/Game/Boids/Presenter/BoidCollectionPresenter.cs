using Boids.MvpUtils;
using Boids.World;
using Impl.Worlds.Game.Boids.Model;

namespace Impl.Worlds.Game.Boids.Presenter
{
    public class BoidCollectionPresenter : APresenter
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

            foreach (var boid in _model.Items.Value)
            {
                
            }
        }
    }
}