using Services.Controllers.Linker;
using UnityEngine;
using Worlds.Abstracts;

namespace Services.Controllers.Spawner.Impl
{
    public class ControllerSpawner : IControllerSpawner
    {
        private readonly IControllerLinker _controllerLinker;

        public ControllerSpawner(IControllerLinker controllerLinker)
        {
            _controllerLinker = controllerLinker;
        }
        
        public TC Spawn<TC, TV>(IModel model)
            where TC : IController, new()
            where TV : IView, new()
        {
            var go = new GameObject();
            
            var viewType = typeof(TV);
            go.name = viewType.Name;

            var viewInstance = go.AddComponent(viewType);
            var controllerInstance = new TC();

            controllerInstance.Model = model; 
            
            _controllerLinker.Link(controllerInstance, (IView)viewInstance);
            
            return controllerInstance;
        }
    }
}