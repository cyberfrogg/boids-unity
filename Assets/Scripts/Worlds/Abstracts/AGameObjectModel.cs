using UnityEngine;

namespace Worlds.Abstracts
{
    public abstract class AGameObjectModel : AModel
    {
        private Vector3 _position;
        private Quaternion _rotation;
        private Vector3 _scale;
        
        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                InvokeChanged();
            }
        }
        
        public Quaternion Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                InvokeChanged();
            }
        }

        public Vector3 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                InvokeChanged();
            }
        }
    }
}