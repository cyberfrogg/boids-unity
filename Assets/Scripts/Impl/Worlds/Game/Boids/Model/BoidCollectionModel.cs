using System.Collections.Generic;
using Boids.MvpUtils;
using Boids.MvpUtils.Impl;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Presenter;
using Impl.Worlds.Game.Boids.View;
using UnityEngine;

namespace Impl.Worlds.Game.Boids.Model
{
    public class BoidCollectionModel : AModel
    {
        public ModelField<List<IEntity<BoidModel, BoidView, BoidPresenter>>> Items { get; set; } = new() { Value = new List<IEntity<BoidModel, BoidView, BoidPresenter>>() };
        public ModelField<IEntity<BoidModel, BoidView, BoidPresenter>[]> OverlapBuffer { get; set; } = new();
        public ModelField<Vector3> FieldCenter { get; set; } = new();
    }
}