using Boids.MvpUtils;
using Boids.Services;
using Boids.World.WorldAbstracts.Entity;

namespace Boids.World.Services.WorldEntityFactoryService
{
    public interface IWorldEntityFactoryService : IService
    {
        IEntity<TM, TV, TP> CreateEmpty<TM, TV, TP>(IWorld world, TM model)
            where TM : IModel
            where TV : IView, new()
            where TP : IPresenter;

        IEntity<TM, TV, TP> CreateFromPrefab<TM, TV, TP>(IWorld world, TM model, string prefabName)
            where TM : IModel
            where TV : IView, new()
            where TP : IPresenter;
    }
}