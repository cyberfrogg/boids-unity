using Boids.World;
using Boids.World.LifeCycle;

namespace Impl.Worlds.Splash
{
    public class SplashWorld : IWorld
    {
        private bool _isEnabled;
        
        public SplashWorld(IWorldLifeCycle worldLifeCycle)
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