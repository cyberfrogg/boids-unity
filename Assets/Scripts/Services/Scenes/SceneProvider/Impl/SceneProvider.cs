using System.Linq;
using Settings.Settings.Scene;
using Settings.SettingsLocator;

namespace Services.Scenes.SceneProvider.Impl
{
    public class SceneProvider : ISceneProvider
    {
        private readonly ISceneSettings _sceneSettings;
        
        public SceneProvider(ISettingsLocator settingsLocator)
        {
            _sceneSettings = settingsLocator.GetSettings<ISceneSettings>();
        }
        
        public IScene GetScene(int index)
        {
            return _sceneSettings.Scenes.First(x => x.Index == index);
        }

        public IScene GetScene(string name)
        {
            return _sceneSettings.Scenes.First(x => x.Name == name);
        }
    }
}