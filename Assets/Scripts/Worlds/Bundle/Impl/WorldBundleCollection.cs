using System.Collections.Generic;
using System.Linq;
using Worlds.Abstracts;

namespace Worlds.Bundle.Impl
{
    public class WorldBundleCollection : IWorldBundleCollection
    {
        private readonly List<IWorldObjectBundle<IController, IModel, IView>> _bundles;

        public WorldBundleCollection()
        {
            _bundles = new List<IWorldObjectBundle<IController, IModel, IView>>();
        }
        
        public IWorldObjectBundle<TC, TM, TV> Get<TC, TM, TV>(int uid)
        {
            var bundle = _bundles.First(x => x.Uid == uid);

            return bundle as IWorldObjectBundle<TC, TM, TV>;
        }

        public void Add(IController controller, IModel model, IView view)
        {
            var uid = model.Uid;
            
            var bundle = new WorldObjectBundle<IController, IModel, IView>(uid, controller, model, view);
            _bundles.Add(bundle);   
        }
    }
}