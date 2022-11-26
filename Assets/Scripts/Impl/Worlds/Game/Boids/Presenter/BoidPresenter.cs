using Boids.MvpUtils;
using Boids.World;
using Boids.World.LifeCycle;
using Impl.Worlds.Game.Boids.Model;
using UnityEngine;

namespace Impl.Worlds.Game.Boids.Presenter
{
    public class BoidPresenter : AGameObjectPresenter, IUpdateListener
    {
        private BoidModel _model;
        
        public BoidPresenter(IWorld world)
        {
            world.LifeCycle.AddUpdateListener(this);
        }

        public void Initialize()
        {
            _model = (BoidModel)Model;
            InitializeGameObjectModel();
        }

        public void Update()
        {
            var newPosition = _model.Position.Value + (Vector3.up * Time.deltaTime);
             _model.Position.SetValueReactive(newPosition);
        }
    }
}