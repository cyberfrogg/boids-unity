using System;
using Boids.MvpUtils;
using Boids.World.WorldAbstracts.Entity;
using Boids.World.WorldAbstracts.Entity.Impl;

namespace Boids.World.Services.WorldEntityLinker.Impl
{
    public class WorldEntityLinker : IWorldEntityLinker
    {
        public IEntity<TM, TV, TP> Link<TM, TV, TP>(IWorld world, TM model, TV view, TP presenter)
            where TM : IModel
            where TV : IView
            where TP : IPresenter
        {
            if (model.Uid.Value != view.Uid)
                throw new ArgumentException($"Uid doesnt match | Model: {model.Uid.Value} != View: {view.Uid}");

            presenter.Model = model;
            presenter.View = view;
            
            var entity = new Entity<TM, TV, TP>(presenter.Model.Uid.Value, model, (TV)presenter.View, presenter);

            world.Entities.Add(entity);

            return entity;
        }
    }
}