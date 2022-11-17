using Boids.Install.Settings;
using UnityEngine;

namespace Boids.Install
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private ContextsInstallerSettings _settings;
        
        private void Awake()
        {
            var installer = new MainInstaller(_settings);
            installer.Install();
        }
    }
}