using Contexts.LifeCycle;
using Services.ServiceLocator;
using Worlds;

namespace Contexts
{
    public interface IContext
    {
        bool IsActive { get; set; }
        IServiceLocator ServiceLocator { get; }
        IContextLifeCycle ContextLifeCycle { get; }   
        IWorld World { get; }
    }
}