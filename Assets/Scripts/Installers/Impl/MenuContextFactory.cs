using Contexts;
using Contexts.Impl.Menu;
using Services.ServiceLocator;

namespace Installers.Impl
{
    public class MenuContextFactory : IContextFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public MenuContextFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        
        public IContext Create()
        {
            return new MenuContext(_serviceLocator);
        }
    }
}