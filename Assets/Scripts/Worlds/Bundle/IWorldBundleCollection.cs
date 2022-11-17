using System.Collections.Generic;
using Worlds.Abstracts;

namespace Worlds.Bundle
{
    public interface IWorldBundleCollection
    {
        int GetUidByTag(EWorldBundleTag tag);
        List<int> GetUidsByTag(EWorldBundleTag tag);
        IWorldObjectBundle<TC, TM, TV> Get<TC, TM, TV>(int uid);
        void Add(IController controller, IModel model, IView view);
    }
}