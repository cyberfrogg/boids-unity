using Boids.World;
using Boids.World.LifeCycle;

namespace Impl.Worlds.Game
{
    public class GameWorld : IWorld
    {
        private bool _isEnabled;

        public GameWorld(IWorldLifeCycle worldLifeCycle)
        {
            LifeCycle = worldLifeCycle;
        }
        
        public IWorldLifeCycle LifeCycle { get; }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                LifeCycle.IsEnabled = value;
                _isEnabled = value;
            }
        }
    }
}
