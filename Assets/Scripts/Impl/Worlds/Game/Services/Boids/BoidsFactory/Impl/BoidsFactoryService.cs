using System.Collections.Generic;
using Boids.MvpUtils.Impl;
using Boids.World;
using Boids.World.Services.WorldEntityFactoryService;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Model;
using Impl.Worlds.Game.Boids.Presenter;
using Impl.Worlds.Game.Boids.View;
using UnityEngine;

namespace Impl.Worlds.Game.Services.Boids.BoidsFactory.Impl
{
    public class BoidsFactoryService : IBoidsFactoryService
    {
        private readonly IWorldEntityFactoryService _worldEntityFactoryService;

        public BoidsFactoryService(IWorldEntityFactoryService worldEntityFactoryService)
        {
            _worldEntityFactoryService = worldEntityFactoryService;
        }
        
        public IEntity<BoidModel, BoidView, BoidPresenter> Create(
            IWorld world,
            Vector3 spawnPosition,
            IEntity<BoidCollectionModel, BoidCollectionView, BoidCollectionPresenter> collection,
            int updateFrameIndex)
        {
            //creating model
            var frameUpdateIndex = Random.Range(1, 1000);
            spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);
            var boidModel = new BoidModel()
            {
                Position = new ModelField<Vector3>(spawnPosition),
                Collection = new ModelField<IEntity<BoidCollectionModel, BoidCollectionView, BoidCollectionPresenter>>(collection),
                LocalScale = new ModelField<Vector3>(Vector3.one),
                Tags = new ModelField<List<string>>(new List<string>() { "boid" }),
                UpdateFrameIndex = new ModelField<int>(frameUpdateIndex)
            };
                
            //create single boid
            var boid = _worldEntityFactoryService.CreateFromPrefab<
                BoidModel,
                BoidView,
                BoidPresenter
            >(world, boidModel, "boid");
            boid.Presenter.Initialize();

            return boid;
        }
    }
}