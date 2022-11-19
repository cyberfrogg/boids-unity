using System;

namespace Boids.MvpUtils.Impl
{
    public class ModelField<T> : IModelField<T>
    {
        private T _value;

        public event Action<T> Changed;

        public void Set(T value, bool silent = false)
        {
            _value = value;

            if (!silent)
                InvokeChanged();
        }

        public T Get()
        {
            return _value;
        }

        private void InvokeChanged()
        {
            Changed?.Invoke(_value);
        }
    }
}