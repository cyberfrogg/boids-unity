using Contexts.LifeCycle;

namespace Services.LifeCycle.Factory
{
    public interface ILifeCycleFactoryService : IService
    {
        IContextLifeCycle Create();
    }
}