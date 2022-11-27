using Boids.MvpUtils;
using UnityEngine;

namespace Impl.Worlds.Game.Camera.View
{
    public class CameraView : AGameObjectView
    {
        [SerializeField] private UnityEngine.Camera _camera;

        public UnityEngine.Camera UnityCamera => _camera;
    }
}