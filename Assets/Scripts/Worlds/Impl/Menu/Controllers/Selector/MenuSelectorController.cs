using System.Linq;
using Contexts;
using Contexts.LifeCycle;
using Services.Input;
using Services.ServiceLocator;
using UnityEngine;
using Worlds.Abstracts;
using Worlds.Impl.Menu.Models.Selector;
using Worlds.Impl.Menu.Views.Selector;

namespace Worlds.Impl.Menu.Controllers.Selector
{
    public class MenuSelectorController : IController, IUpdateListener, IInitializeListener
    {
        private IInputService _inputService;
        
        private MenuSelectorView _view;
        private MenuSelectorModel _model;
        
        public void Initialize(IContext context, IServiceLocator serviceLocator)
        {
            _model.Changed += OnModelChanged;

            _inputService = serviceLocator.GetService<IInputService>();

            PositionItems();
        }
        
        public void Update()
        {
            var horizontalAxis = _inputService.GetAxis(EInputAxisName.Horizontal);
            
            switch (horizontalAxis)
            {
                case < 0:
                    _model.LevelSelected = ClampLevel(_model.LevelSelected - 1);
                    break;
                case > 0:
                    _model.LevelSelected = ClampLevel(_model.LevelSelected + 1);
                    break;
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

        private void OnModelChanged(IModel model)
        {
            _view.OnSelectedLevelIndexChanged(_model.LevelSelected);
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