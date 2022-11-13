using Contexts;
using Worlds.Abstracts;

namespace Services.Controllers.Spawner
{
    public interface IControllerPrefabSpawner : IService
    {
        T SpawnPrefab<T>(IContext context, string name, IModel model) where T : IController, new();
    }
}