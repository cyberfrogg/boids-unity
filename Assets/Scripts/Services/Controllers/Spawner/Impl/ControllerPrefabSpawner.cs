using Services.Controllers.Linker;
using Settings.Settings.Prefab;
using Settings.SettingsLocator;
using UnityEngine;
using Worlds.Abstracts;

namespace Services.Controllers.Spawner.Impl
{
    public class ControllerPrefabSpawner : IControllerPrefabSpawner
    {
        private readonly IControllerLinker _controllerLinker;
        private IPrefabSettings _prefabSettings;
        
        public ControllerPrefabSpawner(ISettingsLocator settingsLocator, IControllerLinker controllerLinker)
        {
            _controllerLinker = controllerLinker;
            _prefabSettings = settingsLocator.GetSettings<IPrefabSettings>();
        }

        public T SpawnPrefab<T>(string viewName, IModel model) where T : IController, new()
        {
            var prefab = _prefabSettings.GetPrefab(viewName);

            var instance = Object.Instantiate(prefab);
            var view = instance.GetComponent<IView>();
            
            var controllerInstance = new T();
            controllerInstance.View = view;
            controllerInstance.Model = model;
            
            _controllerLinker.Link(controllerInstance, view);
            
            return controllerInstance;
        }
    }
}