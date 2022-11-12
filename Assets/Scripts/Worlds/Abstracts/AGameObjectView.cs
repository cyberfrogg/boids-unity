using UnityEngine;

namespace Worlds.Abstracts
{
    public abstract class AGameObjectView : MonoBehaviour, IView
    {
        public int Uid { get; private set; }

        public void InitializeGoView(int uid)
        {
            Uid = uid;
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