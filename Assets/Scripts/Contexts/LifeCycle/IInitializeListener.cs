using Services.ServiceLocator;

namespace Contexts.LifeCycle
{
    public interface IInitializeListener
    {
        void Initialize(IContext context, IServiceLocator serviceLocator);
    }
}