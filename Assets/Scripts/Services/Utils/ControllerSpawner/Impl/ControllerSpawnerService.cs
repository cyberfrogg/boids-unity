using UnityEngine;
using Worlds.Abstracts;

namespace Services.Utils.ControllerSpawner.Impl
{
    public class ControllerSpawnerService : IControllerSpawnerService
    {
        public T Spawn<T, T2>() where T : ControllerBase<ViewBase>, new()
        {
            var go = new GameObject();
            

            var viewType = typeof(T).GetGenericArguments()[0];
            go.name = nameof(viewType);

            var viewInstance = go.AddComponent(viewType);

            var controllerInstance = new T
            {
                View = (ViewBase)viewInstance
            };
            return controllerInstance;
        }
    }
}