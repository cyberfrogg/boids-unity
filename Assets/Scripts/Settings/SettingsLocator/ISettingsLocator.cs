using Services;

namespace Settings.SettingsLocator
{
    public interface ISettingsLocator : IService
    {
        T GetSettings<T>() where T : ISettings;
    }
}