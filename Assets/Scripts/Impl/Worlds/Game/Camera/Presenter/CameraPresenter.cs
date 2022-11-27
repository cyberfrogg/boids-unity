using Boids.MvpUtils;
using Boids.World;
using Impl.Worlds.Game.Camera.Model;
using Impl.Worlds.Game.Camera.View;

namespace Impl.Worlds.Game.Camera.Presenter
{
    public class CameraPresenter : AGameObjectPresenter
    {
        public CameraPresenter(IWorld world)
        {
            
        }

        public void Initialize()
        {
            ((CameraModel)Model).Camera.Value = ((CameraView)View).UnityCamera;
            InitializeGameObjectModel();
        }
    }
}