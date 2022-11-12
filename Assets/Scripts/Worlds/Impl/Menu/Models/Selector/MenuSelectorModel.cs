using System.Collections.Generic;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Models.Selector
{
    public class MenuSelectorModel : AModel
    {
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
                InvokeChanged();
            }
        }

        public IReadOnlyCollection<MenuSelectorItemModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                InvokeChanged();
            }
        }
    }
}