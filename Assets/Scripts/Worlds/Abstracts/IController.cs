using Contexts;

namespace Worlds.Abstracts
{
    public interface IController
    {
        void Initialize(IContext context);
        IModel Model { get; set; }
        IView View { get; set; }
    }
}