using System;
using UnityEngine.SceneManagement;

namespace Services.Scenes.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(IScene scene, Action<IScene> sceneLoadComplete, LoadSceneMode mode = LoadSceneMode.Single);

        void UnLoad(IScene scene, Action<IScene> sceneUnLoadComplete);
    }
}