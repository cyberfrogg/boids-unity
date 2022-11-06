using System.Collections.Generic;
using Core.Scenes;

namespace Settings.Settings
{
    public interface ISceneSettings
    {
        List<IScene> Scenes { get; }
    }
}