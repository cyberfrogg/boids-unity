using System;

namespace Boids.MvpUtils
{
    public interface IModelField<T>
    {
        event Action<T> Changed;
        void Set(T value, bool silent = false);
        T Get();
    }
}