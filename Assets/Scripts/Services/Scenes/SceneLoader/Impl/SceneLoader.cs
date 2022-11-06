using System;
using UnityEngine.SceneManagement;

namespace Services.Scenes.SceneLoader.Impl
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(IScene scene, Action<IScene> sceneLoadComplete, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var operation = SceneManager.LoadSceneAsync(scene.Index, mode);
            operation.completed += (asyncOperation =>
            {
                sceneLoadComplete?.Invoke(scene);
            });
        }

        public void UnLoad(IScene scene, Action<IScene> sceneUnLoadComplete)
        {
            
        }
    }
}