﻿using System.Collections.Generic;
using Boids.MvpUtils;
using Boids.MvpUtils.Impl;
using Boids.Services.Impl.SharedServices.ScenePointer;
using Boids.Services.Impl.SharedServices.SettingsLocator;
using Boids.World;
using Boids.World.Services.WorldEntityFactoryService;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Model;
using Impl.Worlds.Game.Boids.Presenter;
using Impl.Worlds.Game.Boids.View;
using Impl.Worlds.Game.Camera.Model;
using Impl.Worlds.Game.Camera.Presenter;
using Impl.Worlds.Game.Camera.View;
using Impl.Worlds.Game.Settings.BoidsSettings;
using Impl.Worlds.Game.WorldPointers;
using UnityEngine;

namespace Impl.Worlds.Game.Initialize.Presenter
{
    public class GameInitializePresenter : APresenter
    {
        private readonly IWorld _world;
        private readonly IWorldEntityFactoryService _worldEntityFactoryService;
        private readonly IBoidsSettings _boidsSettings;
        private readonly IWorldSceneObjectPointerService _worldSceneObjectPointerService;
        
        public GameInitializePresenter(IWorld world)
        {
            _world = world;
            _worldEntityFactoryService = _world.ServiceLocator.GetService<IWorldEntityFactoryService>();
            _worldSceneObjectPointerService = _world.ServiceLocator.GetService<IWorldSceneObjectPointerService>();
            _boidsSettings = _world.ServiceLocator.GetService<ISettingsLocator>().GetSettings<IBoidsSettings>();
        }

        public void Initialize()
        {
            CreateCamera();
            var boidCollection = CreateBoidsCollection();
            boidCollection.Presenter.Initialize();
        }

        private IEntity<BoidCollectionModel, BoidCollectionView, BoidCollectionPresenter> CreateBoidsCollection()
        {
            // create collection
            var fieldCenter = _worldSceneObjectPointerService.Get<FieldPointer>().Bounds;
            var collection = _worldEntityFactoryService.CreateEmpty<
                BoidCollectionModel,
                BoidCollectionView,
                BoidCollectionPresenter
            >(_world, new BoidCollectionModel()
            {
                FieldCenter = new ModelField<Vector3>(fieldCenter),
                OverlapBuffer = new ModelField<IEntity<BoidModel, BoidView, BoidPresenter>[]>(new IEntity<BoidModel, BoidView, BoidPresenter>[_boidsSettings.BoidsCount])
            });
            
            for (var i = 0; i < _boidsSettings.BoidsCount; i++)
            {
                //creating model
                var spawnPosition = Random.insideUnitSphere * _boidsSettings.BoidsSpawnRadius;
                spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);
                var boidModel = new BoidModel()
                {
                    Position = new ModelField<Vector3>(spawnPosition),
                    Collection = new ModelField<IEntity<BoidCollectionModel, BoidCollectionView, BoidCollectionPresenter>>(collection),
                    LocalScale = new ModelField<Vector3>(Vector3.one),
                    Tags = new ModelField<List<string>>(new List<string>() { "boid" })
                };
                
                //create single boid
                var boid = _worldEntityFactoryService.CreateFromPrefab<
                    BoidModel,
                    BoidView,
                    BoidPresenter
                >(_world, boidModel, "boid");
                boid.Presenter.Initialize();
                
                //add created boid to collection
                collection.Model.Items.Value.Add(boid);
            }

            return collection;
        }
        
        private void CreateCamera()
        {
            var cameraModel = new CameraModel()
            {
                Tags = new ModelField<List<string>>(new List<string>() { "MainCamera" }),
                GoTag = new ModelField<string>("MainCamera"),
                LocalPosition = new ModelField<Vector3>(new Vector3(0, 0, -10)),
            };
            var cameraEntity = _worldEntityFactoryService.CreateFromPrefab<
                CameraModel,
                CameraView,
                CameraPresenter
            >(_world, cameraModel, "MainCamera");
            
            cameraEntity.Presenter.Initialize();
        }
    }
}