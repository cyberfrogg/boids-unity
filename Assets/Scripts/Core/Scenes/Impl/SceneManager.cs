using System;
using UnityEngine.SceneManagement;

namespace Core.Scenes.Impl
{
    public class SceneManager : ISceneManager
    {
        public void Load(IScene scene, Action<IScene> sceneLoadComplete, LoadSceneMode mode = LoadSceneMode.Single)
        {
            
        }

        public void UnLoad(IScene scene, Action<IScene> sceneUnLoadComplete)
        {
            
        }
    }
}