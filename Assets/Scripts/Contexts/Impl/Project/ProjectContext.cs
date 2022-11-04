using Services.Logger;

namespace Contexts.Impl.Project
{
    public class ProjectContext : IContext
    {
        private readonly ILogger _logger;

        public ProjectContext(ILogger logger)
        {
            _logger = logger;
            
            _logger.Log($"{nameof(ProjectContext)} Created!");
        }
    }
}