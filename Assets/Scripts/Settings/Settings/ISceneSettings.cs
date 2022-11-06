using System.Collections.Generic;
using Services.Scenes;

namespace Settings.Settings
{
    public interface ISceneSettings : ISettings
    {
        List<IScene> Scenes { get; }
    }
}