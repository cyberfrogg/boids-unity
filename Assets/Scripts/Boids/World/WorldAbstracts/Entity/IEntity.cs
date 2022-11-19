using Boids.MvpUtils;

namespace Boids.World.WorldAbstracts.Entity
{
    public interface IEntity<TM, TV, TP> 
        where TM : IModel
        where TV : IView
        where TP : IPresenter
    {
        int Uid { get; }
        TM Model { get; }
        TV View { get; }
        TP Presenter { get; }
    }
}