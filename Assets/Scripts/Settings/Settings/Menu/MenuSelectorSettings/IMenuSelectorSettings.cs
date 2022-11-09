using System.Collections.Generic;

namespace Settings.Settings.Menu.MenuSelectorSettings
{
    public interface IMenuSelectorSettings : ISettings
    {
        IReadOnlyCollection<IMenuSelectorSettingsItem> Items { get; }
    }
}