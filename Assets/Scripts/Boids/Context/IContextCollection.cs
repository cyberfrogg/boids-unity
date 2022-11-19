using System.Collections.Generic;
using Boids.Context.Contexts;

namespace Boids.Context
{
    public interface IContextCollection
    {
        IReadOnlyCollection<IContext> Contexts { get; }
        IContext Get(EContextType type);
    }
}