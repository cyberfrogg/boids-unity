using Contexts;
using Contexts.LifeCycle;
using Services.Controllers.Spawner;
using Services.Logger;
using Services.Scenes;
using Services.Scenes.SceneLoader;
using Services.Scenes.SceneProvider;
using Services.ServiceLocator;
using Worlds.Impl.Menu.Controllers.Selector;
using Worlds.Impl.Menu.Models.Selector;
using Worlds.Impl.Menu.Views.Selector;

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

        public MenuInitialize(IContext context, IServiceLocator serviceLocator)
        {
            _context = context;
            _serviceLocator = serviceLocator;

            _logger = _serviceLocator.GetService<ILogger>();
            _sceneProvider = _serviceLocator.GetService<ISceneProvider>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _controllerSpawner = _serviceLocator.GetService<IControllerSpawner>();
            _controllerPrefabSpawner = _serviceLocator.GetService<IControllerPrefabSpawner>();
            
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
            // from empty object
            var menuSelectorController = _controllerSpawner.Spawn<MenuSelectorController, MenuSelectorView>(new MenuSelectorModel());
            menuSelectorController.Initialize(_context, _serviceLocator);               //life cycle
            _context.ContextLifeCycle.AddUpdateListener(menuSelectorController);        //life cycle
            
            // from prefab
            var selectorItemController = _controllerPrefabSpawner.SpawnPrefab<MenuSelectorItemController>("MenuSelectorItem", new MenuSelectorModel());
            _context.ContextLifeCycle.AddUpdateListener(selectorItemController);        //life cycle
        }
    }
}