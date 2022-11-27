using Boids.MvpUtils;
using Boids.Services.Impl.SharedServices.SettingsLocator;
using Boids.World;
using Boids.World.LifeCycle;
using Boids.World.WorldAbstracts.Entity;
using Impl.Worlds.Game.Boids.Model;
using Impl.Worlds.Game.Boids.View;
using Impl.Worlds.Game.Settings.BoidsSettings;
using UnityEngine;

namespace Impl.Worlds.Game.Boids.Presenter
{
    public class BoidPresenter : AGameObjectPresenter, IUpdateListener
    {
        private readonly IBoidsSettings _boidsSettings;
        
        private BoidModel _model;
        
        public BoidPresenter(IWorld world)
        {
            world.LifeCycle.AddUpdateListener(this);

            _boidsSettings = world.ServiceLocator.GetService<ISettingsLocator>().GetSettings<IBoidsSettings>();
        }

        public void Initialize()
        {
            _model = (BoidModel)Model;
            InitializeGameObjectModel();
        }

        public void Update()
        {
            CalculateVelocity();
            //DrawDebug();      // 1200 batches from debug.drawRay? wtf

            var newPosition = _model.Position.Value + (_model.Velocity.Value * Time.deltaTime);
            _model.Position.SetValueReactive(newPosition);
        }

        private void CalculateVelocity()
        {
            _model.Velocity.Value = Vector3.zero;
            _model.Cohesion.Value = Vector3.zero;
            _model.Separation.Value = Vector3.zero;
            _model.Alignment.Value = Vector3.zero;
            _model.SeparationCount.Value = 0;

            var overlapBuffer = _model.Collection.Value.Model.OverlapBuffer.Value;

            var availableOverlappedBoids = 0;
            OverlapBoids(_model.Position.Value, _boidsSettings.CohesionRadius, overlapBuffer);
            
            foreach (var otherBoid in overlapBuffer)
            {
                if(otherBoid == null)
                    continue;
                availableOverlappedBoids++;
                
                _model.Cohesion.Value += otherBoid.Model.Position.Value;
                _model.Alignment.Value += otherBoid.Model.Velocity.Value;

                if (otherBoid.Model.Uid.Value != _model.Uid.Value)
                {
                    var otherBoidPosition = otherBoid.Model.Position.Value;
                    var myPosition = _model.Position.Value;
                    if ((myPosition - otherBoidPosition).magnitude < _boidsSettings.SeparationDistance)
                    {
                        _model.Separation.Value += (myPosition - otherBoidPosition) / (myPosition - otherBoidPosition).magnitude;
                        _model.SeparationCount.Value++;
                    }
                }
            }

            _model.Cohesion.Value /= availableOverlappedBoids;
            _model.Cohesion.Value -= _model.Position.Value;
            
            if ( _model.SeparationCount.Value > 0)
            {
                _model.Separation.Value /=  _model.SeparationCount.Value;
            }

            _model.Alignment.Value /= availableOverlappedBoids;

            _model.Velocity.Value = _model.Cohesion.Value + _model.Separation.Value + _model.Alignment.Value * 2;
            _model.Velocity.Value = Vector3.ClampMagnitude(_model.Velocity.Value, _boidsSettings.MaxVelocity);
        }

        private void OverlapBoids(Vector3 position, float radius, IEntity<BoidModel, BoidView, BoidPresenter>[] buffer)
        {
            var collection = _model.Collection.Value.Model.Items.Value;
            for (var i = 0; i < buffer.Length; i++)
            {
                var boid = collection[i];
                var distance = Vector3.Distance(position, boid.Model.Position.Value);

                buffer[i] = distance < radius ? collection[i] : null;
            }
        }
    }
}