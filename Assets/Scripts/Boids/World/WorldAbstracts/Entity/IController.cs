namespace Boids.World.WorldAbstracts.Entity
{
    public interface IController
    {
        void Initialize(IWorld world);
        IModel Model { get; set; }
        IView View { get; set; }
    }
}