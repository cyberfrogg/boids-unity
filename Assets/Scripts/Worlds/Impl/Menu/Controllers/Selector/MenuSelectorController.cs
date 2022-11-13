using System.Linq;
using Contexts;
using Contexts.LifeCycle;
using Services.Input;
using Services.Raycast;
using UnityEngine;
using Worlds.Abstracts;
using Worlds.Impl.Menu.Models.Selector;
using Worlds.Impl.Menu.Views.Selector;

namespace Worlds.Impl.Menu.Controllers.Selector
{
    public class MenuSelectorController : IController, IUpdateListener
    {
        private IInputService _inputService;
        private IRayCastService _rayCastService;
        
        private MenuSelectorView _view;
        private MenuSelectorModel _model;
        
        public void Initialize(IContext context)
        {
            _inputService = context.ServiceLocator.GetService<IInputService>();
            _rayCastService = context.ServiceLocator.GetService<IRayCastService>();
            
            PositionItems();
        }
        
        public void Update()
        {
            if (_inputService.IsButtonUp(EInputActionName.Fire1))
            {
                
            }
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