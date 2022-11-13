using Contexts.LifeCycle;
using Contexts.LifeCycle.Impl;
using Services.LifeCycle.Factory;
using Services.Logger;
using Services.ServiceLocator;
using Worlds;

namespace Contexts.Impl.Project
{
    public class ProjectContext : IContext
    {
        private readonly ILogger _logger;
        private readonly IServiceLocator _serviceLocator;
        private readonly ILifeCycleFactoryService _lifeCycleFactoryService;

        private bool _isActive;

        public ProjectContext(IServiceLocator serviceLocator)
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

        public IServiceLocator ServiceLocator => _serviceLocator;
        public IContextLifeCycle ContextLifeCycle { get; }
        public IWorld World => null;

        private void OnEnable()
        {
            _logger.Log($"Enabled {nameof(ProjectContext)}");
            
            (ContextLifeCycle as DefaultContextLifeCycle)?.InvokeInitialize(this, _serviceLocator);
        }

        private void OnDisable()
        {
            _logger.Log($"Disable {nameof(ProjectContext)}");
        }
    }
}