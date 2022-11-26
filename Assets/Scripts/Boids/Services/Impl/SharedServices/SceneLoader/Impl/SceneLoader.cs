using System;
using UnityEngine.SceneManagement;

namespace Boids.Services.Impl.SharedServices.SceneLoader.Impl
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(string name, bool isAdaptive, Action<string> loadComplete)
        {
            var operation = SceneManager.LoadSceneAsync(name, isAdaptive ? LoadSceneMode.Additive : LoadSceneMode.Single);
            operation.completed += (asyncOperation =>
            {
                loadComplete?.Invoke(name);
            });
        }

        public void UnLoad(string name, Action<string> unloadComplete)
        {
            var operation = SceneManager.UnloadSceneAsync(name);
            operation.completed += (asyncOperation =>
            {
                unloadComplete?.Invoke(name);
            });
        }
    }
}