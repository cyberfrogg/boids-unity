using System;
using System.Collections.Generic;
using System.Linq;
using Boids.Context.Contexts;

namespace Boids.Context.Impl
{
    public class ContextCollection : IContextCollection
    {
        public IReadOnlyCollection<IContext> Contexts { get; }

        public ContextCollection(IReadOnlyCollection<IContext> contexts)
        {
            Contexts = contexts;

            foreach (var context in Contexts)
            {
                context.World.SwitchRequested += OnContextSwitchRequested;
            }
        }

        private void OnContextSwitchRequested(string contextName)
        {
            var contextNameParseResult = Enum.TryParse<EContextType>(contextName, out var contextType);

            if (!contextNameParseResult)
                throw new KeyNotFoundException($"Can't find context type enum for name: {contextName}");

            foreach (var context in Contexts)
            {
                context.IsEnabled = context.Type == contextType;
            }
        }

        public IContext Get(EContextType type)
        {
            return Contexts.First(x => x.Type == type);
        }
    }
}