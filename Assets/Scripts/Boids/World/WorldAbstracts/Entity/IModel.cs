using System;

namespace Boids.World.WorldAbstracts.Entity
{
    public interface IModel
    {
        event Action<IModel> Changed;
        public int Uid { get; set; }
    }
}