using UnityEngine;

namespace Impl.Worlds.Game.Settings.BoidsSettings.Impl
{
    [CreateAssetMenu(menuName = "Settings/Game/" + nameof(BoidsSettings), fileName = nameof(BoidsSettings))]
    public class BoidsSettings : ScriptableObject, IBoidsSettings
    {
        [SerializeField] private int _boidsCount;

        public int BoidsCount => _boidsCount;
    }
}