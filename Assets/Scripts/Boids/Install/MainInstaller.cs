using Boids.Install.Settings;

namespace Boids.Install
{
    public class MainInstaller
    {
        private readonly ContextsInstallerSettings _settings;

        public MainInstaller(ContextsInstallerSettings settings)
        {
            _settings = settings;
        }
        
        public void Install()
        {
            var contextsInstaller = new ContextCollectionInstaller(_settings);
            contextsInstaller.InstallContextCollection();
        }
    }
}