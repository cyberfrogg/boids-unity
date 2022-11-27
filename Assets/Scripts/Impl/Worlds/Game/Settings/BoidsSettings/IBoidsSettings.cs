using Boids.Services.Impl.SharedServices.SettingsLocator;

namespace Impl.Worlds.Game.Settings.BoidsSettings
{
    public interface IBoidsSettings : ISettings
    {
        int BoidsCount { get; }
        float BoidsSpawnRadius { get; }
        float SeparationDistance { get; }
        float CohesionRadius { get; } 
        float MaxVelocity { get; }
        float BorderRadius { get; }
    }
}