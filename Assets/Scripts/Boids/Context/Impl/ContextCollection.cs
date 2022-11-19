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
        }

        public IContext Get(EContextType type)
        {
            return Contexts.First(x => x.Type == type);
        }
    }
}