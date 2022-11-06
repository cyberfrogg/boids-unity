using Contexts;
using Services.ServiceLocator;

namespace Worlds.Impl.Menu
{
    public class MenuWorld : IWorld
    {
        public string Name => "Menu";
        
        public void Install(IContext context, IServiceLocator serviceLocator)
        {
            var menuInitialize = new MenuInitialize(context, serviceLocator);
        }

        public void Destroy()
        {
            
        }
    }
}