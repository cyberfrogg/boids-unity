namespace Boids.World.LifeCycle
{
    public interface IWorldLifeCycle
    {
        bool IsEnabled { get; set; }
        void AddUpdateListener(IUpdateListener updateListener);
        void RemoveUpdateListener(IUpdateListener updateListener);
    }
}