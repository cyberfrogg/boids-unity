using System.Collections.Generic;

namespace Settings.SettingsLocator.Impl
{
    public class SettingsLocatorFactory : ISettingsLocatorFactory
    {
        private readonly List<ISettings> _settings;

        public SettingsLocatorFactory(List<ISettings> settings)
        {
            _settings = settings;
        }
        
        public ISettingsLocator Create()
        {
            return new SettingsLocator(_settings.AsReadOnly());
        }
    }
}