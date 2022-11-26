using System.Collections.Generic;
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
            DrawDebug();

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
            
            var overlappedBoids = OverlapBoids(_model.Position.Value, _boidsSettings.CohesionRadius);
            foreach (var otherBoid in overlappedBoids)
            {
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

            _model.Cohesion.Value /= overlappedBoids.Count;
            _model.Cohesion.Value -= _model.Position.Value;
            
            if ( _model.SeparationCount.Value > 0)
            {
                _model.Separation.Value /=  _model.SeparationCount.Value;
            }

            _model.Alignment.Value /= overlappedBoids.Count;

            _model.Velocity.Value = _model.Cohesion.Value + _model.Separation.Value + _model.Alignment.Value * 2;
            _model.Velocity.Value = Vector3.ClampMagnitude(_model.Velocity.Value, _boidsSettings.MaxVelocity);
        }

        private void DrawDebug()
        {
            Debug.DrawRay(_model.Position.Value, _model.Separation.Value, Color.green);
            Debug.DrawRay(_model.Position.Value, _model.Cohesion.Value, Color.magenta);
            Debug.DrawRay(_model.Position.Value, _model.Alignment.Value, Color.blue);
        }

        private List<IEntity<BoidModel, BoidView, BoidPresenter>> OverlapBoids(Vector3 position, float radius)
        {
            var result = new List<IEntity<BoidModel, BoidView, BoidPresenter>>();

            foreach (var boid in _model.Collection.Value.Model.Items.Value)
            {
                var distance = Vector3.Distance(position, boid.Model.Position.Value);

                if (distance <= radius)
                {
                    result.Add(boid);
                }
            }

            return result;
        }
    }
}