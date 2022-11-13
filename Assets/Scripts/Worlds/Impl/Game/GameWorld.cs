using Contexts;
using Services.ServiceLocator;
using Worlds.Bundle;
using Worlds.Bundle.Impl;

namespace Worlds.Impl.Game
{
    public class GameWorld : IWorld
    {
        private WorldBundleCollection _bundleCollection;
        
        public void Install(IContext context, IServiceLocator serviceLocator)
        {
            var gameInitialize = new GameInitialize(context, serviceLocator);
            context.ContextLifeCycle.AddInitializeListener(gameInitialize);

            _bundleCollection = new WorldBundleCollection();
        }
        
        public string Name => "Game";

        public IWorldBundleCollection BundleCollection => _bundleCollection;

        public void Destroy()
        {
            
        }
    }
}