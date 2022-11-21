using System;
using Boids.Context.Contexts;
using UnityEngine;

namespace Boids.Install.Settings.ContextBased
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(ContextSettingsContainer), fileName = nameof(ContextSettingsContainer))]
    public class ContextSettingsContainer : ScriptableObject
    {
        [SerializeField] private SplashContextSettings _splashContextSettings;
        [SerializeField] private GameContextSettings _gameContextSettings;
        [SerializeField] private SharedSettings _sharedSettings;

        public SharedSettings SharedSettings => _sharedSettings;
        public IContextSettings GetContextSettings(EContextType contextType)
        {
            return contextType switch
            {
                EContextType.Splash => _splashContextSettings,
                EContextType.Game => _gameContextSettings,
                _ => throw new ArgumentOutOfRangeException(nameof(contextType), contextType, null)
            };
        } 
    }
}