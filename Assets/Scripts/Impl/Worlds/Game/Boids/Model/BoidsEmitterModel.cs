using Boids.MvpUtils;
using Boids.MvpUtils.Impl;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Presenter;
using Impl.Worlds.Game.Boids.View;

namespace Impl.Worlds.Game.Boids.Model
{
    public class BoidsEmitterModel : AModel
    {
        public ModelField<IEntity<BoidCollectionModel, BoidCollectionView, BoidCollectionPresenter>> Collection { get; set; } = new ();
    }
}