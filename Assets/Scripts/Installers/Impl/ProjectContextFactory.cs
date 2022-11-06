using Contexts;
using Contexts.Impl.Project;
using Services.Logger;
using Services.ServiceLocator;

namespace Installers.Impl
{
    public class ProjectContextFactory : IContextFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public ProjectContextFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        
        public IContext Create()
        {
            return new ProjectContext(_serviceLocator);
        }
    }
}