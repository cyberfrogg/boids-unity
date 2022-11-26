using System.Collections.Generic;
using Boids.MvpUtils;
using Boids.MvpUtils.Impl;

namespace Impl.Worlds.Game.Boids.Model
{
    public class BoidCollectionModel : AModel
    {
        public ModelField<List<int>> Items { get; set; } = new ModelField<List<int>>() { Value = new List<int>() };
    }
}