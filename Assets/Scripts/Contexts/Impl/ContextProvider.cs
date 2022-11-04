using System.Collections.Generic;
using Exceptions;
using UnityEngine;
using ILogger = Services.Logger.ILogger;

namespace Contexts.Impl
{
    public class ContextProvider : MonoBehaviour, IContextProvider
    {
        private List<IContext> _contexts;
        private ILogger _logger;
        
        private bool _isInitialized;

        public void Initialize(List<IContext> contexts, ILogger logger)
        {
            if(_isInitialized)
            {
                logger.Warn($"{nameof(ContextProvider)} already Initialized!");
                return;
            }

            _contexts = contexts;
            _logger = logger;
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