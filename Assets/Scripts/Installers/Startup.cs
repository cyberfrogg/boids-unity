using System.Collections.Generic;
using Contexts;
using Contexts.Impl;
using Installers.Impl;
using Services.Logger.Impl;
using UnityEngine;

namespace Installers
{
    public class Startup : MonoBehaviour
    {
        private void Awake()
        {
            Install();
        }

        private void Install()
        {
            var logger = new ConsoleLogger();
            
            var contextFactories = new List<IContextFactory>()
            {
                new ProjectContextContextFactory(logger)
            };
            
            var contexts = CreateContexts(contextFactories);

            var contextProviderObject = new GameObject();
            var contextProvider = contextProviderObject.AddComponent<ContextProvider>();
            contextProvider.Initialize(contexts, logger);
        }

        private List<IContext> CreateContexts(List<IContextFactory> contextFactories)
        {
            var result = new List<IContext>();

            foreach (var installer in contextFactories)
            {
                var context = installer.Create();
                result.Add(context);
            }

            return result;
        }
    }
}