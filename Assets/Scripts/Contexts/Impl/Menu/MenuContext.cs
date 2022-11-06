using Contexts.LifeCycle;
using Contexts.LifeCycle.Impl;
using Services.LifeCycle.Factory;
using Services.Logger;
using Services.ServiceLocator;
using Worlds;
using Worlds.Impl.Menu;

namespace Contexts.Impl.Menu
{
    public class MenuContext : IContext
    {
        private readonly ILogger _logger;
        private readonly IServiceLocator _serviceLocator;
        private readonly ILifeCycleFactoryService _lifeCycleFactoryService;

        private MenuWorld _world;
        private bool _isActive;

        public MenuContext(IServiceLocator serviceLocator)
        {
            _logger = serviceLocator.GetService<ILogger>();
            _serviceLocator = serviceLocator;
            _lifeCycleFactoryService = _serviceLocator.GetService<ILifeCycleFactoryService>();

            ContextLifeCycle = _lifeCycleFactoryService.Create();
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                ContextLifeCycle.IsEnabled = value;
                _isActive = value;

                if (_isActive)
                {
                    OnEnable();
                }
                else
                {
                    OnDisable();
                }
            }
        }
        public IContextLifeCycle ContextLifeCycle { get; }
        public IWorld World => _world;

        private void OnEnable()
        {
            _logger.Log($"Enabled {nameof(MenuContext)}");

            _world = new MenuWorld();
            _world.Install(this, _serviceLocator);

            ContextLifeCycle.IsEnabled = true;
            
            (ContextLifeCycle as DefaultContextLifeCycle)?.InvokeInitialize(this, _serviceLocator);
        }

        private void OnDisable()
        {
            _logger.Log($"Disable {nameof(MenuContext)}");

            ContextLifeCycle.IsEnabled = false;
        }
    }
}