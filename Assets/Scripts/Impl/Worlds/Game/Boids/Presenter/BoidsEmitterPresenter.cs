using System.Linq;
using Boids.MvpUtils;
using Boids.World;
using Boids.World.LifeCycle;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Model;
using Impl.Worlds.Game.Boids.View;
using Impl.Worlds.Game.Camera.Model;
using Impl.Worlds.Game.Camera.Presenter;
using Impl.Worlds.Game.Camera.View;
using Impl.Worlds.Game.Services.Boids.BoidsFactory;
using UnityEngine;

namespace Impl.Worlds.Game.Boids.Presenter
{
    public class BoidsEmitterPresenter : APresenter, IUpdateListener
    {
        private readonly IWorld _world;
        private readonly IBoidsFactoryService _boidsFactoryService;
        
        private BoidsEmitterModel _model;
        
        public BoidsEmitterPresenter(IWorld world)
        {
            _world = world;
            _world.LifeCycle.AddUpdateListener(this);
            _boidsFactoryService = _world.ServiceLocator.GetService<IBoidsFactoryService>();
        }

        public void Initialize()
        {
            _model = (BoidsEmitterModel)Model;
        }

        public void Update()
        {
            if (!Input.GetMouseButton(0))
                return;
            
            CreateNewBoid(GetClickPositionInWorld());
        }

        private void CreateNewBoid(Vector3 spawnPosition)
        {
            var frameUpdateIndex = Random.Range(1, 1000);
            var collectionModel = _model.Collection.Value.Model;
            
            var boid = _boidsFactoryService.Create(_world, spawnPosition, _model.Collection.Value, frameUpdateIndex);
            
            collectionModel.Items.Value.Add(boid);
            var newBuffer = new IEntity<BoidModel, BoidView, BoidPresenter>[collectionModel.Items.Value.Count];
            collectionModel.OverlapBuffer.SetValueReactive(newBuffer);
        }

        private Vector3 GetClickPositionInWorld()
        {
            var cameraUid = _world.Entities.GetByTag("MainCamera").First();
            var camera = _world.Entities.Get<CameraModel, CameraView, CameraPresenter>(cameraUid);

            var mousePosition = Input.mousePosition;
            
            return camera.Model.Camera.Value.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -camera.Model.LocalPosition.Value.z));
        }
    }
}