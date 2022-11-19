using Boids.Services;
using Boids.World;

namespace Boids.Context.Contexts.Impl
{
    public class GameContext : IContext
    {
        private readonly IWorld _world;
        private readonly IServiceLocator _serviceLocator;

        private bool _isEnabled;

        public GameContext(IWorld world, IServiceLocator serviceLocator)
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
        public EContextType Type => EContextType.Game;
    }
}