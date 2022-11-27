using Boids.MvpUtils;
using Boids.MvpUtils.Impl;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Presenter;
using Impl.Worlds.Game.Boids.View;
using UnityEngine;

namespace Impl.Worlds.Game.Boids.Model
{
    public class BoidModel : AGameObjectModel
    {
        public ModelField<Vector3> Cohesion { get; set; } = new();
        public ModelField<Vector3> Velocity { get; set; } = new();
        public ModelField<Vector3> Separation { get; set; } = new();
        public ModelField<int> SeparationCount { get; set; } = new();
        public ModelField<Vector3> Alignment { get; set; } = new();
        public ModelField<IEntity<BoidModel, BoidView, BoidPresenter>[]> OverlapBuffer { get; set; } = new();
        public ModelField<IEntity<BoidCollectionModel, BoidCollectionView, BoidCollectionPresenter>> Collection { get; set; } = new ();
    }
}