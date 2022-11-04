using System;
using UnityEngine.SceneManagement;

namespace Core.Scenes
{
    public interface ISceneManager
    {
        void Load(IScene scene, Action<IScene> sceneLoadComplete, LoadSceneMode mode = LoadSceneMode.Single);

        void UnLoad(IScene scene, Action<IScene> sceneUnLoadComplete);
    }
}