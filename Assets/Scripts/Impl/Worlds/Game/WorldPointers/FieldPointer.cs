using Boids.Services.Impl.SharedServices.ScenePointer;
using UnityEngine;

namespace Impl.Worlds.Game.WorldPointers
{
    public class FieldPointer : MonoBehaviour, IWorldSceneObjectPointer
    {
        [SerializeField] private Bounds _bounds;

        public Bounds Bounds => _bounds;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawWireCube(_bounds.center, _bounds.extents);
        }
    }
}