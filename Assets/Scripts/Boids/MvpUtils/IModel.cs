using System.Collections.Generic;

namespace Boids.MvpUtils
{
    public interface IModel
    {
        IModelField<int> Uid { get; set; }
        IModelField<List<string>> Tags { get; set; }
    }
}