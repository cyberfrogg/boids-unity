using System.Collections.Generic;

namespace Boids.MvpUtils
{
    public abstract class AModel : IModel
    {
        public IModelField<int> Uid { get; set; }
        public IModelField<List<string>> Tags { get; set; }
    }
}