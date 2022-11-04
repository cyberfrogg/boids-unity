using System.Collections.Generic;
using Exceptions;
using Services.ServiceLocator;
using UnityEngine;
using ILogger = Services.Logger.ILogger;

namespace Contexts.Impl
{
    public class ContextProvider : MonoBehaviour, IContextProvider
    {
        private List<IContext> _contexts;
        private IServiceLocator _serviceLocator;
        private ILogger _logger;
        
        private bool _isInitialized;

        public void Initialize(List<IContext> contexts, IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            
            if(_isInitialized)
            {
                _logger.Warn($"{nameof(ContextProvider)} already Initialized!");
                return;
            }

            _logger = _serviceLocator.GetService<ILogger>();
            _contexts = contexts;
            _isInitialized = true;
        }

        public T GetContext<T>()
        {
            foreach (var context in _contexts)
            {
                if (context is T resultContext)
                {
                    return resultContext;
                }
            }

            throw new ContextNotFoundException(typeof(T), $"Context not found with given type: {typeof(T).Name}");
        }
    }
}