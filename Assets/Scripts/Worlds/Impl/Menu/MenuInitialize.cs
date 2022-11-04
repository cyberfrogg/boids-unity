using Contexts;
using Contexts.LifeCycle;
using Services.Logger;
using Services.ServiceLocator;

namespace Worlds.Impl.Menu
{
    public class MenuInitialize : IInitializeListener
    {
        private readonly IContext _context;
        private readonly IServiceLocator _serviceLocator;
        private readonly ILogger _logger;

        public MenuInitialize(IContext context, IServiceLocator serviceLocator)
        {
            _context = context;
            _serviceLocator = serviceLocator;

            _logger = _serviceLocator.GetService<ILogger>();
            
            _context.ContextLifeCycle.AddInitializeListener(this);
        }
        
        public void Initialize(IContext context, IServiceLocator serviceLocator)
        {
            _logger.Log($"{nameof(MenuInitialize)} Initialized!");
        }
    }
}