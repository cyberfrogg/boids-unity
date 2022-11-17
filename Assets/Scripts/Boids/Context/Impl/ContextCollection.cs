using System.Collections.Generic;
using Boids.Context.Contexts;

namespace Boids.Context.Impl
{
    public class ContextCollection : IContextCollection
    {
        public IReadOnlyCollection<IContext> Contexts { get; }

        public ContextCollection(IReadOnlyCollection<IContext> contexts)
        {
            Contexts = contexts;
        }
    }
}