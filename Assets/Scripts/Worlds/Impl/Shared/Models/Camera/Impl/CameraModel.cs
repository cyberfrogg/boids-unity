using Worlds.Abstracts;

namespace Worlds.Impl.Shared.Models.Camera.Impl
{
    public class CameraModel : AGameObjectModel, ICameraModel
    {
        private UnityEngine.Camera _camera;
        
        public UnityEngine.Camera Camera
        {
            get => _camera;
            set
            {
                _camera = value;
                InvokeChanged();
            }
        }
    }
}