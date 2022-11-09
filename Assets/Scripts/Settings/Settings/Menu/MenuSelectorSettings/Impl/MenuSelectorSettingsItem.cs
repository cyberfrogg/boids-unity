using System;
using UnityEngine;

namespace Settings.Settings.Menu.MenuSelectorSettings.Impl
{
    [Serializable]
    public class MenuSelectorSettingsItem : IMenuSelectorSettingsItem
    {
        public string Title => _title;
        public string SceneName => _sceneName;

        [SerializeField] private string _title;
        [SerializeField] private string _sceneName;
    }
}