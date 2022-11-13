using Contexts;
using Services.ServiceLocator;
using Worlds.Bundle;

namespace Worlds
{
    public interface IWorld
    {
        string Name { get; }
        void Install(IContext context, IServiceLocator serviceLocator);
        IWorldBundleCollection BundleCollection { get; }
        void Destroy();
    }
}