using Worlds.Abstracts;

namespace Services.Controllers.Spawner
{
    public interface IControllerPrefabSpawner : IService
    {
        T SpawnPrefab<T>(string name, IModel model) where T : IController, new();
    }
}