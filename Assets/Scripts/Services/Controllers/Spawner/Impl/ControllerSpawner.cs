﻿using Services.Controllers.Linker;
using Services.UidGenerator;
using UnityEngine;
using Worlds.Abstracts;

namespace Services.Controllers.Spawner.Impl
{
    public class ControllerSpawner : IControllerSpawner
    {
        private readonly IControllerLinker _controllerLinker;
        private readonly IUidGenerator _uidGenerator;

        public ControllerSpawner(IControllerLinker controllerLinker, IUidGenerator uidGenerator)
        {
            _controllerLinker = controllerLinker;
            _uidGenerator = uidGenerator;
        }
        
        public TC Spawn<TC, TV>(IModel model)
            where TC : IController, new()
            where TV : IView, new()
        {
            var uid = _uidGenerator.Next();

            var controllerInstance = new TC();

            IView viewInstance;
            
            if (typeof(TV).IsSubclassOf(typeof(AGameObjectView)))
            {
                var go = new GameObject();
            
                var viewType = typeof(TV);
                go.name = viewType.Name;
                viewInstance = (IView)go.AddComponent(viewType);
            }
            else
            {
                viewInstance = new TV();
            }
            
            if(model != null)
                model.Uid = uid;
            
            controllerInstance.Model = model; 
            
            _controllerLinker.Link(controllerInstance, viewInstance);
            
            return controllerInstance;
        }
    }
}