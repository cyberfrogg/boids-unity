using Contexts;
using Contexts.LifeCycle;
using Services.Input;
using Services.ServiceLocator;
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
        }
        
        public void Update()
        {
            var horizontalAxis = _inputService.GetAxis(EInputAxisName.Horizontal);
            
            switch (horizontalAxis)
            {
                case < 0:
                    _model.LevelSelected--;
                    break;
                case > 0:
                    _model.LevelSelected++;
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
    }
}