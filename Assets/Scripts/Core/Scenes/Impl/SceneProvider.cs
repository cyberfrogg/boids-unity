namespace Core.Scenes.Impl
{
    public class SceneProvider : ISceneProvider
    {
        public IScene GetScene(int index)
        {
            var unityScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(index);
            return new Scene(unityScene.buildIndex, unityScene.name);
        }

        public IScene GetScene(string name)
        {
            var unityScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(name);
            return new Scene(unityScene.buildIndex, unityScene.name);
        }
    }
}