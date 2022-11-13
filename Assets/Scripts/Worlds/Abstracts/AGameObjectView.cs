using UnityEngine;

namespace Worlds.Abstracts
{
    public abstract class AGameObjectView : MonoBehaviour, IView
    {
        public int Uid { get; set; }

        public void InitializeGameObjectModel(AGameObjectModel model)
        {
            model.Position = transform.position;
            model.Rotation = transform.rotation;
            model.Scale = transform.localScale;
        }

        public void OnPositionChanged(Vector3 position)
        {
            transform.position = position;
        }
        
        public void OnRotationChanged(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
        
        public void OnScaleChanged(Vector3 scale)
        {
            transform.localScale = scale;
        }
    }
}