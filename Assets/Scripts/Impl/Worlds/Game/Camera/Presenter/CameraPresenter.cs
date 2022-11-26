using Boids.MvpUtils;
using Boids.World;

namespace Impl.Worlds.Game.Camera.Presenter
{
    public class CameraPresenter : AGameObjectPresenter
    {
        public CameraPresenter(IWorld world)
        {
            
        }

        public void Initialize()
        {
            InitializeGameObjectModel();
        }
    }
}