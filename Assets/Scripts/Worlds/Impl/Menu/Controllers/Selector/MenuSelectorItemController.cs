using Contexts.LifeCycle;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Controllers.Selector
{
    public class MenuSelectorItemController : IController, IUpdateListener
    {
        public void Update()
        {
            
        }
        
        public IModel Model { get; set; }
        public IView View { get; set; }
    }
}