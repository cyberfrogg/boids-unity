using Boids.MvpUtils;

namespace Boids.World.WorldAbstracts.Entity.Impl
{
    public class Entity<TM, TV, TP> : IEntity<TM, TV, TP> 
        where TM : IModel 
        where TV : IView 
        where TP : IPresenter
    {
        public Entity(int uid, TM model, TV view, TP presenter)
        {
            Uid = uid;
            Model = model;
            View = view;
            Presenter = presenter;
        }
        
        public int Uid { get; }
        public TM Model { get; }
        public TV View { get; }
        public TP Presenter { get; }
    }
}