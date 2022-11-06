using System.Collections.Generic;
using Newtonsoft.Json;
using Services.Scenes;
using UnityEngine;

namespace Settings.Settings.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SceneSettings), fileName = nameof(SceneSettings))]
    public class SceneSettings : ScriptableObject, ISceneSettings, ISerializationCallbackReceiver
    {
        [HideInInspector] public string SerializedValue;
        
        public List<IScene> Target;

        public List<IScene> Scenes => Target;
        
        public void OnBeforeSerialize()
        {
            if (Target == null)
            {
                SerializedValue = "";
                return;
            }

            SerializedValue = JsonConvert.SerializeObject(Target, Formatting.None, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        }

        public void OnAfterDeserialize()
        {
            var converted = JsonConvert.DeserializeObject<List<IScene>>(SerializedValue, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });

            Target = converted ?? new List<IScene>();
        }
    }
}