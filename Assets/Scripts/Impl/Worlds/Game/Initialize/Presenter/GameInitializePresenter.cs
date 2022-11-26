using System.Collections.Generic;
using Boids.MvpUtils;
using Boids.MvpUtils.Impl;
using Boids.World;
using Boids.World.Services.WorldEntityFactoryService;
using Impl.Worlds.Game.Camera.Model;
using Impl.Worlds.Game.Camera.Presenter;
using Impl.Worlds.Game.Camera.View;
using UnityEngine;

namespace Impl.Worlds.Game.Initialize.Presenter
{
    public class GameInitializePresenter : APresenter
    {
        private readonly IWorld _world;
        private readonly IWorldEntityFactoryService _specialGameWorldService;
        
        public GameInitializePresenter(IWorld world)
        {
            _world = world;
            _specialGameWorldService = _world.ServiceLocator.GetService<IWorldEntityFactoryService>();
        }

        public void Initialize()
        {
            var cameraModel = new CameraModel()
            {
                Tags = new ModelField<List<string>>(new List<string>() { "MainCamera" }),
                GoTag = new ModelField<string>("MainCamera"),
                LocalPosition = new ModelField<Vector3>(new Vector3(0, 0, -10)),
            };
            var cameraEntity = _specialGameWorldService.CreateFromPrefab<
                CameraModel,
                CameraView,
                CameraPresenter
            >(_world, cameraModel, "MainCamera");
            
            cameraEntity.Presenter.Initialize();
        }
    }
}