using System.Collections.Generic;
using Boids.Context.Contexts;
using Boids.Services.Impl.SharedServices.SettingsLocator;
using UnityEngine;

namespace Boids.Install.Settings.ContextBased
{
    [CreateAssetMenu(menuName = "Installers/ContextSettings/" + nameof(SplashContextSettings), fileName = nameof(SplashContextSettings))]
    public class SplashContextSettings : ScriptableObject, IContextSettings
    {
        public EContextType ContextType => EContextType.Splash;

        public IReadOnlyCollection<ISettings> Settings 
            => new List<ISettings>()
            {

            };
    }
}