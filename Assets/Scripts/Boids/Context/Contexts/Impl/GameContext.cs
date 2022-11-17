using Boids.World;

namespace Boids.Context.Contexts.Impl
{
    public class GameContext : IContext
    {
        private readonly IWorld _world;
        private bool _isEnabled;

        public GameContext(IWorld world)
        {
            _world = world;
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