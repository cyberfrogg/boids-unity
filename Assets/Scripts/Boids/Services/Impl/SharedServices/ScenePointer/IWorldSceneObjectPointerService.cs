using UnityEngine;

namespace Boids.Services.Impl.SharedServices.ScenePointer
{
    /// <summary>
    /// Uses for accessing sceneObjectPointers. Uses FindObjectOfType. Recommended to use it only on initialization
    /// </summary>
    public interface IWorldSceneObjectPointerService : IService
    {
        T Get<T>() where T : MonoBehaviour, IWorldSceneObjectPointer;
    }
}