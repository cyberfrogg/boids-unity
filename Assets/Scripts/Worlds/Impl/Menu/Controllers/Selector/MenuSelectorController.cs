using System.Linq;
using Contexts;
using Contexts.LifeCycle;
using Exceptions;
using Services.Input;
using Services.Raycast;
using UnityEngine;
using Worlds.Abstracts;
using Worlds.Bundle;
using Worlds.Impl.Menu.Models.Selector;
using Worlds.Impl.Menu.Views.Selector;
using Worlds.Impl.Shared.Controllers.Camera;
using Worlds.Impl.Shared.Models.Camera;
using Worlds.Impl.Shared.Views.Camera;

namespace Worlds.Impl.Menu.Controllers.Selector
{
    public class MenuSelectorController : IController, IUpdateListener
    {
        private IInputService _inputService;
        private IRayCastService _rayCastService;
        private IContext _context; 
        
        private MenuSelectorView _view;
        private MenuSelectorModel _model;
        
        public void Initialize(IContext context)
        {
            _context = context;
            
            _inputService = context.ServiceLocator.GetService<IInputService>();
            _rayCastService = context.ServiceLocator.GetService<IRayCastService>();
            
            PositionItems();
        }
        
        public void Update()
        {
            if (!_inputService.IsButtonUp(EInputActionName.Fire1))
                return;
            
            var camera = GetCamera();
                
            var isHitSuccess = _rayCastService.RayCast2D(camera, _inputService.PointerPosition, out MenuSelectorItemView itemView, out var hit);
            
            if(!isHitSuccess && itemView != null)
                return;

            var itemBundle = _context.World.BundleCollection.Get<MenuSelectorItemController, MenuSelectorModel, MenuSelectorView>(itemView.Uid);
            
            Debug.Log(itemBundle.View.Uid);
        }

        private ICameraController GetCamera()
        {
            var cameraUid = _context.World.BundleCollection.GetUidByTag(EWorldBundleTag.Camera);

            if (cameraUid == 0)
                throw new UidWithTagNotFoundException(EWorldBundleTag.Camera);
                
            var cameraBundle = _context.World.BundleCollection.Get<ICameraController, ICameraModel, ICameraView>(cameraUid);
            return cameraBundle.Controller;
        }

        public IModel Model
        {
            get => _model;
            set => _model = (MenuSelectorModel)value;
        }

        public IView View
        {
            get => _view;
            set => _view = (MenuSelectorView)value;
        }

        private int ClampLevel(int index)
        {
            return Mathf.Clamp(index, 0, _model.Items.Count - 1);
        }

        private void PositionItems()
        {
            for (var i = 0; i < _model.Items.Count; i++)
            {
                var item = _model.Items.ElementAt(i);
                item.Position = new Vector3(i * item.Width, 0, 0);
            }
        }
    }
}