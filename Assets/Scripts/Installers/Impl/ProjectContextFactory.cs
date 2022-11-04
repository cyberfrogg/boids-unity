using Contexts;
using Contexts.Impl.Project;
using Services.Logger;
using Services.ServiceLocator;

namespace Installers.Impl
{
    public class ProjectContextFactory : IContextFactory
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly ILogger _logger;

        public ProjectContextFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _logger = _serviceLocator.GetService<ILogger>();
        }
        
        public IContext Create()
        {
            return new ProjectContext(_logger, _serviceLocator);
        }
    }
}