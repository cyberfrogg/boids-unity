using System.Collections.Generic;
using System.Linq;
using Exceptions;

namespace Settings.SettingsLocator.Impl
{
    public class SettingsLocator : ISettingsLocator
    {
        private IReadOnlyCollection<ISettings> _settings;

        public SettingsLocator(IReadOnlyCollection<ISettings> settings)
        {
            _settings = settings;
        }
        
        public T GetSettings<T>() where T : ISettings
        {
            var foundSettings = _settings.OfType<T>();

            if (!foundSettings.Any())
                throw new ServiceNotFoundException(typeof(T), $"Settings {typeof(T).Name} not found");

            return foundSettings.First();
        }
    }
}