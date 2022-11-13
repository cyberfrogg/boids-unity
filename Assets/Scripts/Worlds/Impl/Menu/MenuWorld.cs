using Contexts;
using Services.ServiceLocator;
using Worlds.Bundle;
using Worlds.Bundle.Impl;

namespace Worlds.Impl.Menu
{
    public class MenuWorld : IWorld
    {
        private WorldBundleCollection _bundleCollection;
        
        public void Install(IContext context, IServiceLocator serviceLocator)
        {
            var menuInitialize = new MenuInitialize(context, serviceLocator);

            _bundleCollection = new WorldBundleCollection();
        }
        
        public string Name => "Menu";

        public IWorldBundleCollection BundleCollection => _bundleCollection;

        public void Destroy()
        {
            
        }
    }
}