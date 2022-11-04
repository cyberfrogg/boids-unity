using Contexts.LifeCycle;

namespace Contexts
{
    public interface IContext
    {
        bool IsActive { get; set; }
        IContextLifeCycle ContextLifeCycle { get; }   
    }
}