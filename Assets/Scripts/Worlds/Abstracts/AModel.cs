using System;

namespace Worlds.Abstracts
{
    public class AModel : IModel
    {
        public event Action<IModel> Changed;

        private int _uid;

        public int Uid
        {
            get => _uid;
            set
            {
                _uid = value;
                InvokeChanged();
            }
        }
        
        protected void InvokeChanged()
        {
            Changed?.Invoke(this);
        }
    }
}