using System.Collections.Generic;
using Boids.World.LifeCycle;
using UnityEngine;

namespace Boids.Install.InstallImpl.World.LifeCycle
{
    public class WorldLifeCycle : MonoBehaviour, IWorldLifeCycle
    {
        private List<IUpdateListener> _updateListeners;

        private bool _isEnabled;
        
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                gameObject.SetActive(value);
                _isEnabled = value;
            }
        }

        public void Initialize()
        {
            _updateListeners = new List<IUpdateListener>();
        }
        
        public void AddUpdateListener(IUpdateListener updateListener)
        {
            _updateListeners.Add(updateListener);
        }

        public void RemoveUpdateListener(IUpdateListener updateListener)
        {
            _updateListeners.Remove(updateListener);
        }

        private void Update()
        {
            for (var i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].Update();
            }
        }
    }
}