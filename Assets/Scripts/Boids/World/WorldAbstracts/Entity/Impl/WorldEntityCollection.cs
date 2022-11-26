using System;
using System.Collections.Generic;
using System.Linq;
using Boids.MvpUtils;

namespace Boids.World.WorldAbstracts.Entity.Impl
{
    public class WorldEntityCollection : IWorldEntityCollection
    {
        private readonly List<IEntity<IModel, IView, IPresenter>> _entities = new ();

        public IReadOnlyCollection<IEntity<IModel, IView, IPresenter>> Collection => _entities;

        public void Add<TM, TV, TC>(IEntity<TM, TV, TC> entity) 
            where TM : IModel 
            where TV : IView
            where TC : IPresenter
        {
            var sameUidEntities = _entities.Count(x => x.Uid == entity.Uid);

            if (sameUidEntities != 0)
                throw new ArgumentException($"Entity with same uid ({entity.Uid}) already exists in this {nameof(WorldEntityCollection)}");
            
            _entities.Add((IEntity<IModel, IView, IPresenter>)entity);
        }

        public IEntity<TM, TV, TC> Get<TM, TV, TC>(int uid) 
            where TM : IModel 
            where TV : IView 
            where TC : IPresenter
        {
            if (_entities.Count == 0)
                return null;

            var entity = _entities.First(x => x.Uid == uid);

            if (entity == null)
                return null;

            return entity as IEntity<TM, TV, TC>;
        }

        public IReadOnlyCollection<int> GetByTag(string tag)
        {
            if (_entities.Count == 0)
                return null;

            return _entities
                .Where(x => x.Model.Tags.Value.Contains(tag))
                .Select(x => x.Uid)
                .ToList();
        }
    }
}