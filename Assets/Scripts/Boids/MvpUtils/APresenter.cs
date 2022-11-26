namespace Boids.MvpUtils
{
    public abstract class APresenter : IPresenter
    {
        public IModel Model { get; set; }
        public IView View { get; set; }
    }
}