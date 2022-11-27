using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Boids.Services.Impl.SharedServices.ScenePointer.Impl
{
    public class WorldSceneObjectPointerService : IWorldSceneObjectPointerService
    {
        public T Get<T>() where T : MonoBehaviour, IWorldSceneObjectPointer
        {
            var found = Object.FindObjectOfType<T>();

            if (found == null)
                throw new NullReferenceException($"SceneObjectPointer not found for type: {typeof(T).Name}");

            return found;
        }
    }
}