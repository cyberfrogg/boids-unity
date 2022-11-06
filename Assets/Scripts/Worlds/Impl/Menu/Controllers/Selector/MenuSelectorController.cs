using Contexts;
using Contexts.LifeCycle;
using Services.ServiceLocator;
using UnityEngine;
using Worlds.Abstracts;
using Worlds.Impl.Menu.Models.Selector;
using Worlds.Impl.Menu.Views.Selector;

namespace Worlds.Impl.Menu.Controllers.Selector
{
    public class MenuSelectorController : IController, IUpdateListener, IInitializeListener
    {
        private MenuSelectorView _view;
        private MenuSelectorModel _model;
        
        public void Initialize(IContext context, IServiceLocator serviceLocator)
        {
            _model.Changed += OnModelChanged;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _model.LevelSelected--;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _model.LevelSelected++;
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
    }
}