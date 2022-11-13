using Contexts;
using Services.Controllers.Linker;
using Services.UidGenerator;
using Settings.Settings.Prefab;
using Settings.SettingsLocator;
using UnityEngine;
using Worlds.Abstracts;

namespace Services.Controllers.Spawner.Impl
{
    public class ControllerPrefabSpawner : IControllerPrefabSpawner
    {
        private readonly IControllerLinker _controllerLinker;
        private readonly IUidGenerator _uidGenerator;
        private readonly IPrefabSettings _prefabSettings;
        
        public ControllerPrefabSpawner(ISettingsLocator settingsLocator, IControllerLinker controllerLinker, IUidGenerator uidGenerator)
        {
            _controllerLinker = controllerLinker;
            _uidGenerator = uidGenerator;
            _prefabSettings = settingsLocator.GetSettings<IPrefabSettings>();
        }

        public T SpawnPrefab<T>(IContext context, string viewName, IModel model) where T : IController, new()
        {
            var uid = _uidGenerator.Next();
            
            var prefab = _prefabSettings.GetPrefab(viewName);

            var instance = Object.Instantiate(prefab);
            var view = instance.GetComponent<AGameObjectView>();
            
            if(view != null)
                view.Uid = uid;
            
            if(model != null)
                model.Uid = uid;
            
            var controllerInstance = new T
            {
                View = view,
                Model = model
            };

            controllerInstance.Initialize(context);
            _controllerLinker.Link(context, controllerInstance, view);
            
            return controllerInstance;
        }
    }
}