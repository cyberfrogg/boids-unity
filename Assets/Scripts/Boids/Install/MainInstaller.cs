using Boids.Context.Contexts;
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
            var contextsCollection = contextsInstaller.InstallContextCollection();

            contextsCollection.Get(EContextType.Splash).IsEnabled = true;
        }
    }
}