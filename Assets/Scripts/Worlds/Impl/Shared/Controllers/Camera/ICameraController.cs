using Worlds.Impl.Shared.Models.Camera;

namespace Worlds.Impl.Shared.Controllers.Camera
{
    public interface ICameraController
    {
        ICameraModel CameraModel { get; }
    }
}