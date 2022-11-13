using Contexts;
using Worlds.Abstracts;

namespace Services.Controllers.Linker.Impl
{
    public class ControllerLinker : IControllerLinker
    {
        public void Link(IContext context, IController controller, IView view)
        {
            context.World.BundleCollection.Add(controller, controller.Model, view);
            controller.View = view;
        }
    }
}