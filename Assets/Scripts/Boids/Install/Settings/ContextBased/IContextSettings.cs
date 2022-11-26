using System.Collections.Generic;
using Boids.Context.Contexts;
using Boids.Services.Impl.SharedServices.SettingsLocator;

namespace Boids.Install.Settings.ContextBased
{
    public interface IContextSettings
    {
        EContextType ContextType { get; }
        IReadOnlyCollection<ISettings> Settings { get; }
    }
}