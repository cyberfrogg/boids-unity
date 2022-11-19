namespace Boids.Services.Impl.SharedServices.SettingsLocator
{
    public interface ISettingsLocator : IService
    {
        T GetSettings<T>() where T : ISettings;
    }
}