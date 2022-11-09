using System;
using System.Collections.Generic;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Models.Selector
{
    public class MenuSelectorModel : IModel
    {
        public event Action<IModel> Changed;
        
        private int _levelSelected;
        private IReadOnlyCollection<MenuSelectorItemModel> _items;

        public MenuSelectorModel(int levelSelected, IReadOnlyCollection<MenuSelectorItemModel> items)
        {
            _levelSelected = levelSelected;
            _items = items;
        }
        
        public int LevelSelected
        {
            get => _levelSelected;
            set
            {
                _levelSelected = value;
                Changed?.Invoke(this);
            }
        }

        public IReadOnlyCollection<MenuSelectorItemModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                Changed?.Invoke(this);
            }
        }
    }
}