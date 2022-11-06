using Worlds.Abstracts;

namespace Services.Controllers.ControllerSpawner
{
    public interface IControllerSpawner : IService
    {
        TC Spawn<TC, TV>(IModel model)
            where TC : IController, new()
            where TV : IView, new();
    }
}