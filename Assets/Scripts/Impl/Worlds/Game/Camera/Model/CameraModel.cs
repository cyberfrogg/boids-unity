using Boids.MvpUtils;
using Boids.MvpUtils.Impl;

namespace Impl.Worlds.Game.Camera.Model
{
    public class CameraModel : AGameObjectModel
    {
        public ModelField<UnityEngine.Camera> Camera { get; set; } = new ();
    }
}