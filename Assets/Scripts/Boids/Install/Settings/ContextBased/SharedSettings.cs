using System.Collections.Generic;
using Boids.Services.Impl.SharedServices.SettingsLocator;
using Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.PrefabSettings.Impl;
using Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.SceneCollectionSettings.Impl;
using UnityEngine;

namespace Boids.Install.Settings.ContextBased
{
    [CreateAssetMenu(menuName = "Installers/ContextSettings/" + nameof(SharedSettings), fileName = nameof(SharedSettings))]
    public class SharedSettings : ScriptableObject
    {
        [SerializeField] private SceneCollectionSettings _sceneCollectionSettings;
        [SerializeField] private PrefabSettings _prefabSettings;

        public IReadOnlyCollection<ISettings> Settings 
            => new List<ISettings>()
            {
                _sceneCollectionSettings,
                _prefabSettings
            };
    }
}