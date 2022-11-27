using Boids.Services.Impl.SharedServices.ScenePointer;
using UnityEngine;

namespace Impl.Worlds.Game.WorldPointers
{
    public class FieldPointer : MonoBehaviour, IWorldSceneObjectPointer
    {
        public Vector3 Bounds => transform.position;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}