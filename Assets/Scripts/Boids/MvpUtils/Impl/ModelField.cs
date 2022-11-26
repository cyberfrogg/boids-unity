using System;

namespace Boids.MvpUtils.Impl
{
    public class ModelField<T> : IModelField<T>
    {
        public event Action<T> Changed;
        
        public T Value { get; set; }

        public ModelField(T value)
        {
            Value = value;
        }
        
        public ModelField()
        {
            Value = default;
        }

        public void SetValueReactive(T value)
        {
            Value = value;
            InvokeChanged();
        }

        private void InvokeChanged()
        {
            Changed?.Invoke(Value);
        }
    }
}