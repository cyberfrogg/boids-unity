using Boids.Services.Impl.SharedServices.SettingsLocator;

namespace Impl.Worlds.Game.Settings.BoidsSettings
{
    public interface IBoidsSettings : ISettings
    {
        int BoidsCount { get; }
    }
}