using Worlds.Abstracts;

namespace Services.Controllers.Linker
{
    public interface IControllerLinker : IService
    {
        public void Link(IController controller, IView view);
    }
}