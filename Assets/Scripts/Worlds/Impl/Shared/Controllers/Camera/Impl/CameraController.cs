using Contexts;
using Contexts.LifeCycle;
using Worlds.Abstracts;
using Worlds.Impl.Shared.Models.Camera;
using Worlds.Impl.Shared.Models.Camera.Impl;
using Worlds.Impl.Shared.Views.Camera.Impl;

namespace Worlds.Impl.Shared.Controllers.Camera.Impl
{
    public class CameraController : IController, IUpdateListener, ICameraController
    {
        private CameraView _view;
        private CameraModel _model;
        
        public void Initialize(IContext context)
        {
            _view.InitializeGameObjectModel(_model);
            _model.Camera = _view.Camera;
            _model.Changed += OnModelChanged;
        }

        public void Update()
        {
            
        }

        private void OnModelChanged(IModel model)
        {
            _view.OnPositionChanged(_model.Position);
            _view.OnRotationChanged(_model.Rotation);
            _view.OnScaleChanged(_model.Scale);
        }

        public IModel Model
        {
            get => _model;
            set => _model = (CameraModel)value;
        }

        public IView View
        {
            get => _view;
            set => _view = (CameraView)value;
        }

        public ICameraModel CameraModel => _model;
    }
}