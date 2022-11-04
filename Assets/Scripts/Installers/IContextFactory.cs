using Contexts;

namespace Installers
{
    public interface IContextFactory
    {
        IContext Create();
    }
}