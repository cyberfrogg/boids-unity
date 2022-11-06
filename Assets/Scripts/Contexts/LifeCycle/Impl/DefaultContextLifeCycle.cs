using System.Collections.Generic;
using Services.ServiceLocator;
using UnityEngine;

namespace Contexts.LifeCycle.Impl
{
    public class DefaultContextLifeCycle : MonoBehaviour, IContextLifeCycle
    {
        private List<IInitializeListener> _initializeListeners;
        private List<IAwakeListener> _awakeListeners;
        private List<IUpdateListener> _updateListeners;

        private bool _isEnabled;

        public void Initialize()
        {
            _initializeListeners = new List<IInitializeListener>();
            _awakeListeners = new List<IAwakeListener>();
            _updateListeners = new List<IUpdateListener>();
        }

        public void InvokeInitialize(IContext context, IServiceLocator serviceLocator)
        {
            if(!IsEnabled)
                return;
            
            for (var i = 0; i < _initializeListeners.Count; i++)
            {
                _initializeListeners[i].Initialize(context, serviceLocator);
            }   
        }

        public void InvokeAwake()
        {
            if(!IsEnabled)
                return;
            
            for (var i = 0; i < _awakeListeners.Count; i++)
            {
                _awakeListeners[i].Awake();
            }   
        }
        
        public void InvokeUpdate()
        {
            if(!IsEnabled)
                return;

            for (var i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].Update();
            }   
        }


        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                gameObject.SetActive(value);
                _isEnabled = value;
            }
        }

        public void AddInitializeListener(IInitializeListener initializeListener)
        {
            _initializeListeners.Add(initializeListener);
        }

        public void RemoveInitializeListener(IInitializeListener initializeListener)
        {
            _initializeListeners.Remove(initializeListener);
        }

        public void AddAwakeListener(IAwakeListener awakeListener)
        {
            _awakeListeners.Add(awakeListener);
        }

        public void RemoveAwakeListener(IAwakeListener awakeListener)
        {
            _awakeListeners.Remove(awakeListener);
        }

        public void AddUpdateListener(IUpdateListener updateListener)
        {
            _updateListeners.Add(updateListener);
        }

        public void RemoveUpdateListener(IUpdateListener updateListener)
        {
            _updateListeners.Remove(updateListener);
        }
    }
}