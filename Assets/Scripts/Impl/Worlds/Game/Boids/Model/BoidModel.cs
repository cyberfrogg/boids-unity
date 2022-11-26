using Boids.MvpUtils;
using Boids.MvpUtils.Impl;

namespace Impl.Worlds.Game.Boids.Model
{
    public class BoidModel : AGameObjectModel
    {
        public ModelField<int> CollectionUid { get; set; } = new ();
    }
}