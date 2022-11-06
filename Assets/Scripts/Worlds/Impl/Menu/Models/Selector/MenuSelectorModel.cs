using System;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Models.Selector
{
    public class MenuSelectorModel : IModel
    {
        public event Action<IModel> Changed;
        
        private int _levelSelected;

        public int LevelSelected
        {
            get => _levelSelected;
            set
            {
                _levelSelected = value;
                Changed?.Invoke(this);
            }
        }
    }
}