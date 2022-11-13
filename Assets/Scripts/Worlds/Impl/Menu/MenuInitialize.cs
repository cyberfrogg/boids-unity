using System.Collections.Generic;
using Contexts;
using Contexts.LifeCycle;
using Services.Controllers.Spawner;
using Services.Logger;
using Services.Scenes;
using Services.Scenes.SceneLoader;
using Services.Scenes.SceneProvider;
using Services.ServiceLocator;
using Settings.Settings.Menu.MenuSelectorSettings;
using Settings.SettingsLocator;
using Worlds.Impl.Menu.Controllers.Selector;
using Worlds.Impl.Menu.Models.Selector;
using Worlds.Impl.Menu.Views.Selector;
using Worlds.Impl.Shared.Controllers.Camera.Impl;
using Worlds.Impl.Shared.Models.Camera.Impl;

namespace Worlds.Impl.Menu
{
    public class MenuInitialize : IInitializeListener
    {
        private readonly IContext _context;
        private readonly IServiceLocator _serviceLocator;
        
        private readonly ILogger _logger;
        private readonly ISceneProvider _sceneProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly IControllerSpawner _controllerSpawner;
        private readonly IControllerPrefabSpawner _controllerPrefabSpawner;

        private readonly IMenuSelectorSettings _menuSelectorSettings;

        public MenuInitialize(IContext context, IServiceLocator serviceLocator)
        {
            _context = context;
            _serviceLocator = serviceLocator;

            _logger = _serviceLocator.GetService<ILogger>();
            _sceneProvider = _serviceLocator.GetService<ISceneProvider>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _controllerSpawner = _serviceLocator.GetService<IControllerSpawner>();
            _controllerPrefabSpawner = _serviceLocator.GetService<IControllerPrefabSpawner>();
            _menuSelectorSettings = _serviceLocator.GetService<ISettingsLocator>().GetSettings<IMenuSelectorSettings>();
            
            _context.ContextLifeCycle.AddInitializeListener(this);
        }
        
        public void Initialize(IContext context, IServiceLocator serviceLocator)
        {
            LoadScene();
        }

        private void LoadScene()
        {
            var menuScene = _sceneProvider.GetScene("Menu");
            _sceneLoader.Load(menuScene, OnMenuSceneLoaded);
        }

        private void OnMenuSceneLoaded(IScene scene)
        {
            CreateCamera();
            
            CreateMenuSelector();
        }

        private void CreateCamera()
        {
            _controllerPrefabSpawner.SpawnPrefab<CameraController>(_context, "MenuCamera", new CameraModel());
        }
        
        private void CreateMenuSelector()
        {
            var menuSelectorModel = new MenuSelectorModel(0, CreateMenuSelectorItems());
            
            var menuSelectorController = _controllerSpawner.Spawn<MenuSelectorController, MenuSelectorView>(_context, menuSelectorModel);
            _context.ContextLifeCycle.AddUpdateListener(menuSelectorController);
        }
        
        private IReadOnlyCollection<MenuSelectorItemModel> CreateMenuSelectorItems()
        {
            // from prefabs
            var menuSelectorItems = new List<MenuSelectorItemModel>();
            foreach (var itemSetting in _menuSelectorSettings.Items)
            {
                var itemModel = new MenuSelectorItemModel(itemSetting.Title, itemSetting.SceneName);
                _controllerPrefabSpawner.SpawnPrefab<MenuSelectorItemController>(_context, "MenuSelectorItem", itemModel);
                
                menuSelectorItems.Add(itemModel);
            }

            return menuSelectorItems;
        }
    }
}