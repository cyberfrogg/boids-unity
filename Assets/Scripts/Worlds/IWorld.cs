using Contexts;
using Services.ServiceLocator;

namespace Worlds
{
    public interface IWorld
    {
        string Name { get; }
        void Install(IContext context, IServiceLocator serviceLocator);
        void Destroy();
    }
}