using System.Collections.Generic;
using Settings;
using Settings.Settings.Menu.MenuSelectorSettings.Impl;
using Settings.Settings.Prefab.Impl;
using Settings.Settings.Scene.Impl;
using UnityEngine;

namespace Installers
{
    [CreateAssetMenu(menuName = "Utils/" + nameof(SettingsContainer), fileName = nameof(SettingsContainer))]
    public class SettingsContainer : ScriptableObject
    {
        [SerializeField] private SceneSettings _sceneSettings;
        [SerializeField] private PrefabSettings _prefabSettings;
        [Header("Menu:")]
        [SerializeField] private MenuSelectorSettings _menuSelectorSettings;
        
        public IReadOnlyCollection<ISettings> GetSettings()
        {
            var settings = new List<ISettings>()
            {
                _sceneSettings,
                _prefabSettings,
                _menuSelectorSettings
            };

            return settings.AsReadOnly();
        }
    }
}