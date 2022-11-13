using UnityEngine;
using Worlds.Abstracts;
using Worlds.Impl.Shared.Controllers.Camera;

namespace Services.Raycast
{
    public interface IRayCastService : IService
    {
        bool RayCast2D<T>(Vector2 position, out T view, out RaycastHit2D hit) where T : AGameObjectView;
        bool RayCast2D<T>(ICameraController cameraController, Vector2 screenPosition, out T view, out RaycastHit2D hit) where T : AGameObjectView;
    }
}