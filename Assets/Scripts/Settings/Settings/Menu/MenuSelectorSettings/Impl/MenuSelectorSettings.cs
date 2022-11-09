using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Settings.Settings.Menu.MenuSelectorSettings.Impl
{
    [CreateAssetMenu(menuName = "Settings/Menu/" + nameof(MenuSelectorSettings), fileName = nameof(MenuSelectorSettings))]
    public class MenuSelectorSettings : ScriptableObject, IMenuSelectorSettings
    {
        [SerializeField] private List<MenuSelectorSettingsItem> _items;

        public IReadOnlyCollection<IMenuSelectorSettingsItem> Items =>
            _items.Cast<IMenuSelectorSettingsItem>().ToList().AsReadOnly();
    }
}