using System.Collections.Generic;
using Settings;
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
        
        public IReadOnlyCollection<ISettings> GetSettings()
        {
            var settings = new List<ISettings>()
            {
                _sceneSettings,
                _prefabSettings
            };

            return settings.AsReadOnly();
        }
    }
}