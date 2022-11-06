using Contexts.LifeCycle;
using Contexts.LifeCycle.Impl;
using Services.LifeCycle.Factory;
using Services.Logger;
using Services.ServiceLocator;

namespace Contexts.Impl.Menu
{
    public class MenuContext : IContext
    {
        private readonly ILogger _logger;
        private readonly IServiceLocator _serviceLocator;
        private readonly ILifeCycleFactoryService _lifeCycleFactoryService;

        private bool _isActive;

        public MenuContext(ILogger logger, IServiceLocator serviceLocator)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _lifeCycleFactoryService = _serviceLocator.GetService<ILifeCycleFactoryService>();

            _logger.Log($"{nameof(MenuContext)} Created!");

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

        private void OnEnable()
        {
            (ContextLifeCycle as DefaultContextLifeCycle)?.InvokeInitialize(this, _serviceLocator);
        }

        private void OnDisable()
        {
            
        }
    }
}