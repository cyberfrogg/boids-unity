namespace Contexts.LifeCycle
{
    public interface IInitializeListener
    {
        void Initialize(IContext context);
    }
}