using System.Collections.Generic;
using UnityEngine;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.SceneCollectionSettings.Impl
{
    [CreateAssetMenu(menuName = "Settings/Shared/" + nameof(SceneCollectionSettings), fileName = nameof(SceneCollectionSettings))]
    public class SceneCollectionSettings : ScriptableObject, ISceneCollectionSettings
    {
        [SerializeField] private List<SceneCollectionSettingsScene> _scenes;

        public IReadOnlyCollection<ISceneCollectionSettingsScene> Scenes => _scenes;
    }
}