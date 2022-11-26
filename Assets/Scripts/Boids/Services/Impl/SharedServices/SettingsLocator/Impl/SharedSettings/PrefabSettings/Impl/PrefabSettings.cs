using System.Collections.Generic;
using UnityEngine;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.PrefabSettings.Impl
{
    [CreateAssetMenu(menuName = "Settings/Shared/" + nameof(PrefabSettings), fileName = nameof(PrefabSettings))]
    public class PrefabSettings : ScriptableObject, IPrefabSettings
    {
        [SerializeField] private List<PrefabSettingsItem> _allPrefabs;

        public IReadOnlyCollection<PrefabSettingsItem> AllPrefabs => _allPrefabs;

        public GameObject GetPrefab(string name)
        {
            foreach (var prefabItem in AllPrefabs)
            {
                if (prefabItem.Name == name)
                    return prefabItem.Prefab;
            }

            throw new KeyNotFoundException($"Can't find prefab with name: {name}");
        }
    }
}