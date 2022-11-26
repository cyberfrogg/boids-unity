using Boids.Context.Contexts;

namespace Boids.Install.ContextInstallers
{
    public interface IContextInstaller
    {
        IContext Install();
    }
}