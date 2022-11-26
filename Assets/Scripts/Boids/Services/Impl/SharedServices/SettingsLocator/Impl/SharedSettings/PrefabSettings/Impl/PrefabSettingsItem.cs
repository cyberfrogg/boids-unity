using System;
using UnityEngine;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.PrefabSettings.Impl
{
    [Serializable]
    public struct PrefabSettingsItem
    {
        public string Name;
        public GameObject Prefab;
    }
}