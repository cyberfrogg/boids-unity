using System.Collections.Generic;
using Boids.Context.Contexts;
using Boids.Services.Impl.SharedServices.SettingsLocator;
using UnityEngine;

namespace Boids.Install.Settings.ContextBased
{
    [CreateAssetMenu(menuName = "Installers/ContextSettings/" + nameof(GameContextSettings), fileName = nameof(GameContextSettings))]
    public class GameContextSettings : ScriptableObject, IContextSettings
    {
        public EContextType ContextType => EContextType.Game;

        public IReadOnlyCollection<ISettings> Settings 
            => new List<ISettings>()
            {

            };
    }
}