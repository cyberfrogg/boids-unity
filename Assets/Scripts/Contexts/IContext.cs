using Contexts.LifeCycle;
using Worlds;

namespace Contexts
{
    public interface IContext
    {
        bool IsActive { get; set; }
        IContextLifeCycle ContextLifeCycle { get; }   
        IWorld World { get; }
    }
}