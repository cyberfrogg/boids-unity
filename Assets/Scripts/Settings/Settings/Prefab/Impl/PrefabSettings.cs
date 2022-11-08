using System.Collections.Generic;
using System.Linq;
using Exceptions;
using UnityEngine;
using ILogger = Services.Logger.ILogger;

namespace Settings.Settings.Prefab.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PrefabSettings), fileName = nameof(PrefabSettings))]
    public class PrefabSettings : ScriptableObject, IPrefabSettings
    {
        private readonly ILogger _logger;
        
        [SerializeField] private List<PrefabSettingsItem> _items;

        public PrefabSettings(ILogger logger)
        {
            _logger = logger;
        }
        
        public GameObject GetPrefab(string name)
        {
            var prefab = _items.First(x => x.Name == name);
            
            if(prefab == null)
            {
                _logger.Exception(new PrefabNotFoundException(name, $"Prefab {name} not found!"));
                return null;
            }

            return prefab.GameObject;
        }
    }
}