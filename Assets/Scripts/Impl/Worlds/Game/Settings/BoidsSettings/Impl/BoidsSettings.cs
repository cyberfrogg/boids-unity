using UnityEngine;

namespace Impl.Worlds.Game.Settings.BoidsSettings.Impl
{
    [CreateAssetMenu(menuName = "Settings/Game/" + nameof(BoidsSettings), fileName = nameof(BoidsSettings))]
    public class BoidsSettings : ScriptableObject, IBoidsSettings
    {
        [SerializeField] private int _boidsCount;
        [SerializeField] private float _boidsSpawnRadius;
        [SerializeField] private float _cohesionRadius;
        [SerializeField] private float _separationDistance;
        [SerializeField] private float _maxVelocity; 

        public int BoidsCount => _boidsCount;
        public float BoidsSpawnRadius => _boidsSpawnRadius;
        public float SeparationDistance => _separationDistance;
        public float CohesionRadius => _cohesionRadius;
        public float MaxVelocity => _maxVelocity;
    }
}