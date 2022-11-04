using Contexts;
using Contexts.Impl.Project;
using Services.Logger;

namespace Installers.Impl
{
    public class ProjectContextContextFactory : IContextFactory
    {
        private readonly ILogger _logger;

        public ProjectContextContextFactory(ILogger logger)
        {
            _logger = logger;
        }
        
        public IContext Create()
        {
            return new ProjectContext(_logger);
        }
    }
}