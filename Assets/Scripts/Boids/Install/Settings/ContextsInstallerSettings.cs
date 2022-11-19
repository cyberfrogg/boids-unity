using System.Collections.Generic;
using Boids.Install.Settings.ContextBased;
using UnityEngine;

namespace Boids.Install.Settings
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(ContextsInstallerSettings), fileName = nameof(ContextsInstallerSettings))]
    public class ContextsInstallerSettings : ScriptableObject
    {
        [SerializeField] private List<ContextsInstallerSettingsItem> _contexts;
        [SerializeField] private ContextSettingsContainer _settingsContainer;

        public IReadOnlyCollection<ContextsInstallerSettingsItem> Contexts => _contexts;
        public ContextSettingsContainer SettingsContainer => _settingsContainer;
    }
}