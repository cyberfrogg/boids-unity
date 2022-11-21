using System;
using UnityEngine;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.SceneCollectionSettings.Impl
{
    [Serializable]
    public class SceneCollectionSettingsScene : ISceneCollectionSettingsScene
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private int _sceneBuildIndex;

        public string Name => _sceneName;
        public int BuildIndex => _sceneBuildIndex;
    }
}