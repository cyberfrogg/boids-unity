namespace Worlds.Abstracts
{
    public interface IController
    {
        IModel Model { get; set; }
        IView View { get; set; }
    }
}