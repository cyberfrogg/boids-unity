namespace Contexts.LifeCycle
{
    public interface IContextLifeCycle
    {
        bool IsEnabled { get; set; }
        void AddInitializeListener(IInitializeListener initializeListener);
        void RemoveInitializeListener(IInitializeListener initializeListener);
        void AddAwakeListener(IAwakeListener awakeListener);
        void RemoveAwakeListener(IAwakeListener awakeListener);
        void AddUpdateListener(IUpdateListener updateListener);
        void RemoveUpdateListener(IUpdateListener updateListener);
    }
}