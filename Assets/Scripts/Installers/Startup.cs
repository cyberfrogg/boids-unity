using System.Collections.Generic;
using Contexts;
using Contexts.Impl;
using Contexts.Impl.Project;
using Installers.Impl;
using Services.ServiceLocator.Impl;
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
            var serviceLocator = new ServiceLocatorFactory().Create();
            
            var contextFactories = new List<IContextFactory>()
            {
                new ProjectContextFactory(serviceLocator),
                new MenuContextFactory(serviceLocator)
            };
            
            var contexts = CreateContexts(contextFactories);
            var contextProviderObject = new GameObject();
            contextProviderObject.name = nameof(ContextProvider);
            var contextProvider = contextProviderObject.AddComponent<ContextProvider>();
            contextProvider.Initialize(contexts, serviceLocator);

            EnableProjectContext(contextProvider);
        }

        private void EnableProjectContext(IContextProvider contextProvider)
        {
            contextProvider.GetContext<ProjectContext>().IsActive = true;
        }

        private List<IContext> CreateContexts(List<IContextFactory> contextFactories)
        {
            var result = new List<IContext>();

            foreach (var factory in contextFactories)
            {
                var context = factory.Create();
                result.Add(context);
            }

            return result;
        }
    }
}