using System.Collections.Generic;
using Settings;
using Settings.Settings.Impl;
using UnityEngine;

namespace Installers
{
    [CreateAssetMenu(menuName = "Utils/" + nameof(SettingsContainer), fileName = nameof(SettingsContainer))]
    public class SettingsContainer : ScriptableObject
    {
        [SerializeField] private SceneSettings _sceneSettings;
        
        public IReadOnlyCollection<ISettings> GetSettings()
        {
            var settings = new List<ISettings>()
            {
                _sceneSettings
            };

            return settings.AsReadOnly();
        }
    }
}