using Contexts;
using Contexts.Impl.Menu;
using Services.Logger;
using Services.ServiceLocator;

namespace Installers.Impl
{
    public class MenuContextFactory : IContextFactory
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly ILogger _logger;

        public MenuContextFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _logger = _serviceLocator.GetService<ILogger>();
        }
        
        public IContext Create()
        {
            return new MenuContext(_logger, _serviceLocator);
        }
    }
}