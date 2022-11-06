using Contexts;
using Contexts.LifeCycle;
using Services.Logger;
using Services.Scenes;
using Services.Scenes.SceneLoader;
using Services.Scenes.SceneProvider;
using Services.ServiceLocator;

namespace Worlds.Impl.Menu
{
    public class MenuInitialize : IInitializeListener
    {
        private readonly IContext _context;
        private readonly IServiceLocator _serviceLocator;
        private readonly ILogger _logger;
        private readonly ISceneProvider _sceneProvider;
        private readonly ISceneLoader _sceneLoader;

        public MenuInitialize(IContext context, IServiceLocator serviceLocator)
        {
            _context = context;
            _serviceLocator = serviceLocator;

            _logger = _serviceLocator.GetService<ILogger>();
            _sceneProvider = _serviceLocator.GetService<ISceneProvider>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            
            _context.ContextLifeCycle.AddInitializeListener(this);
        }
        
        public void Initialize(IContext context, IServiceLocator serviceLocator)
        {
            _logger.Log($"{nameof(MenuInitialize)} Initialized!");

            LoadScene();
        }

        private void LoadScene()
        {
            var menuScene = _sceneProvider.GetScene("Menu");
            _sceneLoader.Load(menuScene, OnMenuSceneLoaded);
        }

        private void OnMenuSceneLoaded(IScene scene)
        {
            _logger.Log($"Scene {scene.Name} loaded!");
        }
    }
}