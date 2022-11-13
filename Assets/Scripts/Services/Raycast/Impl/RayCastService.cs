using UnityEngine;
using Worlds.Abstracts;
using Worlds.Impl.Shared.Controllers.Camera;

namespace Services.Raycast.Impl
{
    public class RayCastService : IRayCastService
    {
        public bool RayCast2D<T>(Vector2 position, out T view, out RaycastHit2D hit) where T : AGameObjectView
        {
            var rhit = Physics2D.Raycast(position, Vector3.forward);

            if (rhit.collider == null)
            {
                view = null;
                hit = new RaycastHit2D();
                return false;
            }

            hit = rhit;
            view = rhit.transform.gameObject.GetComponent<T>();
            return true;
        }

        public bool RayCast2D<T>(ICameraController cameraController, Vector2 screenPosition, out T view, out RaycastHit2D hit) where T : AGameObjectView
        {
            var pos = cameraController.CameraModel.Camera.ScreenToWorldPoint(screenPosition);
            var rhit = Physics2D.Raycast(pos, Vector3.forward);

            if (rhit.collider == null)
            {
                view = null;
                hit = new RaycastHit2D();
                return false;
            }

            hit = rhit;
            view = rhit.transform.gameObject.GetComponent<T>();
            return true;
        }
    }
}