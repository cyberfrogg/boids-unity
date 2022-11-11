using Contexts;
using Contexts.LifeCycle;
using Services.ServiceLocator;
using Worlds.Abstracts;
using Worlds.Impl.Menu.Models.Selector;
using Worlds.Impl.Menu.Views.Selector;

namespace Worlds.Impl.Menu.Controllers.Selector
{
    public class MenuSelectorItemController : IController, IInitializeListener
    {
        private MenuSelectorItemModel _model;
        private MenuSelectorItemView _view;
        
        public void Initialize(IContext context, IServiceLocator serviceLocator)
        {
            OnModelChanged(Model);
            _model.Changed += OnModelChanged;
        }

        private void OnModelChanged(IModel model)
        {
            _view.Title = _model.Title;
            _view.Position = _model.Position;
        }

        public IModel Model
        {
            get => _model;
            set => _model = (MenuSelectorItemModel)value;
        }

        public IView View
        {
            get => _view;
            set => _view = (MenuSelectorItemView)value;
        }
    }
}