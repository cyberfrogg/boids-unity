using Contexts;
using Worlds.Abstracts;

namespace Services.Controllers.Linker
{
    public interface IControllerLinker : IService
    {
        public void Link(IContext context, IController controller, IView view);
    }
}