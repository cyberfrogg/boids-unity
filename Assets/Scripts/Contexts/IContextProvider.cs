using System.Collections.Generic;
using Services.Logger;

namespace Contexts
{
    public interface IContextProvider
    {
        void Initialize(List<IContext> contexts, ILogger logger);
        T GetContext<T>();
    }
}