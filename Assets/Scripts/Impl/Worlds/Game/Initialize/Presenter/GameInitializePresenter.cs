﻿using System.Collections.Generic;
using Boids.MvpUtils;
using Boids.MvpUtils.Impl;
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
using UnityEngine;

namespace Impl.Worlds.Game.Initialize.Presenter
{
    public class GameInitializePresenter : APresenter
    {
        private readonly IWorld _world;
        private readonly IWorldEntityFactoryService _worldEntityFactoryService;
        private readonly IBoidsSettings _boidsSettings;
        
        public GameInitializePresenter(IWorld world)
        {
            _world = world;
            _worldEntityFactoryService = _world.ServiceLocator.GetService<IWorldEntityFactoryService>();
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
            var collection = _worldEntityFactoryService.CreateEmpty<
                BoidCollectionModel,
                BoidCollectionView,
                BoidCollectionPresenter
            >(_world, new BoidCollectionModel());
            
            for (var i = 0; i < _boidsSettings.BoidsCount; i++)
            {
                var boidModel = new BoidModel()
                {
                    CollectionUid = new ModelField<int>(collection.Uid),
                    LocalScale = new ModelField<Vector3>(Vector3.one)
                };
                var boid = _worldEntityFactoryService.CreateFromPrefab<
                    BoidModel,
                    BoidView,
                    BoidPresenter
                >(_world, boidModel, "boid");
                boid.Presenter.Initialize();
                
                collection.Model.Items.Value.Add(boid.Model.Uid.Value);
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