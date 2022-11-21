using UnityEngine;

namespace Boids.MvpUtils
{
    public abstract class AGameObjectView : MonoBehaviour, IView
    {
        public int Uid { get; set; }
    }
}