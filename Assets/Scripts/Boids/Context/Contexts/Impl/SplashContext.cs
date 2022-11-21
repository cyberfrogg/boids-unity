using System;
using Boids.Services;
using Boids.World;

namespace Boids.Context.Contexts.Impl
{
    public class SplashContext : IContext
    {
        private readonly IWorld _world;
        private readonly IServiceLocator _serviceLocator;

        private bool _isEnabled;

        public SplashContext(IWorld world, IServiceLocator serviceLocator)
        {
            _world = world;
            _serviceLocator = serviceLocator;
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _world.IsEnabled = value;
                _isEnabled = value;
            }
        }

        public event Action<string> SwitchRequested;
        public IWorld World => _world;
        public EContextType Type => EContextType.Splash;
    }
}