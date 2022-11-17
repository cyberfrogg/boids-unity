using UnityEngine;
using Worlds.Abstracts;

namespace Worlds.Impl.Shared.Views.Camera.Impl
{
    public class CameraView : AGameObjectView, ICameraView
    {
        [SerializeField] private UnityEngine.Camera _cameraComponent;
        
        public int Uid { get; set; }

        public UnityEngine.Camera Camera => _cameraComponent;
    }
}