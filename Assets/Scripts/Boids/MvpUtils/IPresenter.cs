namespace Boids.MvpUtils
{
    public interface IPresenter
    {
        IModel Model { get; set; }
        IView View { get; set; }
    }
}