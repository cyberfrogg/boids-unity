using System.Collections.Generic;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings
{
    public class SharedSettingsLocatorFactory : ISettingsFactory
    {
        private readonly IReadOnlyCollection<ISettings> _settings;

        public SharedSettingsLocatorFactory(IReadOnlyCollection<ISettings> settings)
        {
            _settings = settings;
        }
        
        public ISettingsLocator Create()
        {
            return new SettingsLocator(_settings);
        }
    }
}