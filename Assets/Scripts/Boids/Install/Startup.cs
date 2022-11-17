using UnityEngine;

namespace Boids.Install
{
    public class Startup : MonoBehaviour
    {
        private void Awake()
        {
            var installer = new MainInstaller();
            installer.Install();
        }
    }
}