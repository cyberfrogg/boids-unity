using System.Collections.Generic;
using System.Linq;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl
{
    public class SettingsLocator : ISettingsLocator
    {
        private readonly IReadOnlyCollection<ISettings> _services;

        public SettingsLocator(IReadOnlyCollection<ISettings> services)
        {
            _services = services;
        }
        
        public T GetSettings<T>() where T : ISettings
        {
            var foundServices = _services.OfType<T>().ToList();

            if (foundServices.Count == 0)
                throw new KeyNotFoundException($"Service {typeof(T).Name} not found");

            return foundServices[1];
        }
    }
}