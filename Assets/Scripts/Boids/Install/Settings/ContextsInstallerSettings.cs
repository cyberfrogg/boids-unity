using System.Collections.Generic;
using UnityEngine;

namespace Boids.Install.Settings
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(ContextsInstallerSettings), fileName = nameof(ContextsInstallerSettings))]
    public class ContextsInstallerSettings : ScriptableObject
    {
        [SerializeField] private List<ContextsInstallerSettingsItem> _contexts;

        public IReadOnlyCollection<ContextsInstallerSettingsItem> Contexts => _contexts;
    }
}