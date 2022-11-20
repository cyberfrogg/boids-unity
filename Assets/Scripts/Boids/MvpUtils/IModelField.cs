using System;

namespace Boids.MvpUtils
{
    public interface IModelField<T>
    {
        event Action<T> Changed;
        T Value { get; set; }
        void SetValueReactive(T value);
    }
}