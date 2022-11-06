using UnityEngine;
using Worlds.Abstracts;

namespace Services.Controllers.ControllerSpawner.Impl
{
    public class ControllerSpawner : IControllerSpawner
    {
        
        public TC Spawn<TC, TV>(IModel model)
            where TC : IController, new()
            where TV : IView, new()
        {
            var go = new GameObject();
            
            var viewType = typeof(TV);
            go.name = nameof(viewType);

            var viewInstance = go.AddComponent(viewType);

            var controllerInstance = new TC();
            controllerInstance.View = (IView)viewInstance;
            controllerInstance.Model = model; 
            return controllerInstance;
        }
    }
}