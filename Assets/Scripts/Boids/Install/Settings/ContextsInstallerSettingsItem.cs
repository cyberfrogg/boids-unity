using System;
using Boids.Context.Contexts;
using UnityEngine;

namespace Boids.Install.Settings
{
    [Serializable]
    public class ContextsInstallerSettingsItem
    {
        [SerializeField] private EContextType _type;
        public EContextType Type => _type;
    }
}