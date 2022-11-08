using UnityEngine;

namespace Settings.Settings.Prefab
{
    public interface IPrefabSettings : ISettings
    {
        GameObject GetPrefab(string name);
    }
}