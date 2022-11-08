using Worlds.Abstracts;

namespace Services.Controllers.Linker.Impl
{
    public class ControllerLinker : IControllerLinker
    {
        public void Link(IController controller, IView view)
        {
            controller.View = view;
        }
    }
}