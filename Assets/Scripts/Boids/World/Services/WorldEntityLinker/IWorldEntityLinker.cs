using Boids.MvpUtils;
using Boids.Services;
using Boids.World.WorldAbstracts.Entity;

namespace Boids.World.Services.WorldEntityLinker
{
    public interface IWorldEntityLinker : IService
    {
        IEntity<TM, TV, TP> Link<TM, TV, TP>(IWorld world, TM model, TV view, TP presenter)
            where TM : IModel
            where TV : IView
            where TP : IPresenter;
    }
}