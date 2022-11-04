using System.Collections.Generic;
using Services.ServiceLocator;

namespace Contexts
{
    public interface IContextProvider
    {
        void Initialize(List<IContext> contexts, IServiceLocator serviceLocator);
        T GetContext<T>();
    }
}