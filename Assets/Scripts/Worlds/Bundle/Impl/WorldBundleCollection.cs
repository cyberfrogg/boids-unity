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

        public int GetUidByTag(EWorldBundleTag tag)
        {
            var found = GetUidsByTag(tag);

            return found.Count == 0 ? 0 : found[0];
        }

        public List<int> GetUidsByTag(EWorldBundleTag tag)
        {
            var found = _bundles.Where(x => x.HasModel && x.Model.Tag == tag).ToList();

            if (found.Count == 0)
                return new List<int>();

            return found.Select(x => x.Uid).ToList();
        }

        public IWorldObjectBundle<TC, TM, TV> Get<TC, TM, TV>(int uid)
        {
            var bundle = _bundles.First(x => x.Uid == uid);
            
            //bundle = IWorldObject<IController, IModel, IView>

            return (IWorldObjectBundle<TC, TM, TV>)bundle;      // invalid cast
        }

        public void Add(IController controller, IModel model, IView view)
        {
            var uid = model.Uid;
            
            var bundle = new WorldObjectBundle<IController, IModel, IView>(uid, controller, model, view);
            _bundles.Add(bundle);   
        }
    }
}