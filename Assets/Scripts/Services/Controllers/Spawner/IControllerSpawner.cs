using Contexts;
using Worlds.Abstracts;

namespace Services.Controllers.Spawner
{
    public interface IControllerSpawner : IService
    {
        TC Spawn<TC, TV>(IContext context, IModel model)
            where TC : IController, new()
            where TV : IView, new();
    }
}