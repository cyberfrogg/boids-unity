using System.Collections.Generic;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.SceneCollectionSettings
{
    public interface ISceneCollectionSettings : ISettings
    {
        IReadOnlyCollection<ISceneCollectionSettingsScene> Scenes { get; }
    }
}