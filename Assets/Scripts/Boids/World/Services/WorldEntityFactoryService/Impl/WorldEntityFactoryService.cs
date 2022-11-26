using System;
using System.Collections.Generic;
using Boids.MvpUtils;
using Boids.MvpUtils.Impl;
using Boids.Services.Impl.SharedServices.SettingsLocator;
using Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.PrefabSettings;
using Boids.World.Services.UidGenerator;
using Boids.World.Services.WorldEntityLinker;
using Boids.World.WorldAbstracts.Entity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Boids.World.Services.WorldEntityFactoryService.Impl
{
    public class WorldEntityFactoryService : IWorldEntityFactoryService
    {
        private readonly IUidGenerator _uidGenerator;
        private readonly IWorldEntityLinker _worldEntityLinker;

        public WorldEntityFactoryService(
            IUidGenerator uidGenerator,
            IWorldEntityLinker worldEntityLinker
            )
        {
            _uidGenerator = uidGenerator;
            _worldEntityLinker = worldEntityLinker;
        }
        
        public IEntity<TM, TV, TP> CreateEmpty<TM, TV, TP>(IWorld world, TM model) 
            where TM : IModel
            where TV : IView, new ()
            where TP : IPresenter
        {
            var uid = _uidGenerator.Next();
            
            var presenter = (TP)Activator.CreateInstance(typeof(TP), world);
            presenter.Model = model;

            TV viewInstance;
            if (typeof(TV).IsSubclassOf(typeof(AGameObjectView)))
            {
                var viewType = typeof(TV);
                var go = new GameObject()
                {
                    name = viewType.Name
                };
                
                viewInstance = (TV)(IView)(AGameObjectView)go.AddComponent(viewType);
            }
            else
            {
                viewInstance = new TV();
            }
            
            if(viewInstance != null)
                viewInstance.Uid = uid;

            if (model != null)
            {
                model.Uid = new ModelField<int>() { Value = uid };
                model.Tags ??= new ModelField<List<string>>() { Value = new List<string>() };
            }

            return _worldEntityLinker.Link(world, model, viewInstance, presenter);
        }

        public IEntity<TM, TV, TP> CreateFromPrefab<TM, TV, TP>(IWorld world, TM model, string prefabName)
            where TM : IModel 
            where TV : IView, new() 
            where TP : IPresenter
        {
            var prefabSettings = world.ServiceLocator.GetService<ISettingsLocator>().GetSettings<IPrefabSettings>();
            var prefab = prefabSettings.GetPrefab(prefabName);
            
            var uid = _uidGenerator.Next();
            
            var presenter = (TP)Activator.CreateInstance(typeof(TP), world);
            presenter.Model = model;
            
            var viewType = typeof(TV);
            var prefabInstance = Object.Instantiate(prefab);
            var viewInstance = (TV)(IView)(AGameObjectView)prefabInstance.GetComponent(viewType);
            
            if(viewInstance != null)
                viewInstance.Uid = uid;
            
            if (model != null)
            {
                model.Uid = new ModelField<int>() { Value = uid };
                model.Tags ??= new ModelField<List<string>>() { Value = new List<string>() };
            }
            
            return _worldEntityLinker.Link(world, model, viewInstance, presenter);
        }
    }
}