using Boids.Services;
using Boids.World;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Model;
using Impl.Worlds.Game.Boids.Presenter;
using Impl.Worlds.Game.Boids.View;
using UnityEngine;

namespace Impl.Worlds.Game.Services.Boids.BoidsFactory
{
    public interface IBoidsFactoryService : IService
    {
        IEntity<BoidModel, BoidView, BoidPresenter> Create(
            IWorld world,
            Vector3 spawnPosition, 
            IEntity<BoidCollectionModel, BoidCollectionView, BoidCollectionPresenter> collection,
            int updateFrameIndex
            );
    }
}