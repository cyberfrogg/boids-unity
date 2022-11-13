using Worlds.Abstracts;

namespace Worlds.Bundle
{
    public interface IWorldBundleCollection
    {
        IWorldObjectBundle<TC, TM, TV> Get<TC, TM, TV>(int uid);
        void Add(IController controller, IModel model, IView view);
    }
}