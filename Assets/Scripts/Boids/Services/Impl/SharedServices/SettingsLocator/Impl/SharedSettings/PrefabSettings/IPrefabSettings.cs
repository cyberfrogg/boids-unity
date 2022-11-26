using System.Collections.Generic;
using Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.PrefabSettings.Impl;
using UnityEngine;

namespace Boids.Services.Impl.SharedServices.SettingsLocator.Impl.SharedSettings.PrefabSettings
{
    public interface IPrefabSettings : ISettings
    {
        IReadOnlyCollection<PrefabSettingsItem> AllPrefabs { get; }
        GameObject GetPrefab(string name);
    }
}