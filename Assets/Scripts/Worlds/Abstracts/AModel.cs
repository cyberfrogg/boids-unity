using System;
using Worlds.Bundle;

namespace Worlds.Abstracts
{
    public class AModel : IModel
    {
        public event Action<IModel> Changed;

        private int _uid;
        private EWorldBundleTag _tag;

        public int Uid
        {
            get => _uid;
            set
            {
                _uid = value;
                InvokeChanged();
            }
        }

        public EWorldBundleTag Tag
        {
            get => _tag;
            set
            {
                _tag = value;
                InvokeChanged();
            }
        }

        protected void InvokeChanged()
        {
            Changed?.Invoke(this);
        }
    }
}