using System.Collections.Generic;
using Boids.MvpUtils;

namespace Boids.World.WorldAbstracts.Entity
{
    public interface IWorldEntityCollection
    {
        IReadOnlyCollection<IEntity<IModel, IView, IPresenter>> Collection { get; }

        void Add<TM, TV, TC>(IEntity<TM, TV, TC> entity)
            where TM : IModel 
            where TV : IView
            where TC : IPresenter;
        
        IEntity<TM, TV, TC> Get<TM, TV, TC>(int uid) 
            where TM : IModel 
            where TV : IView 
            where TC : IPresenter;

        IReadOnlyCollection<int> GetByTag(string tag);
    }
}