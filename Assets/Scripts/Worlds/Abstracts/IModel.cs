using System;

namespace Worlds.Abstracts
{
    public interface IModel
    {
        event Action<IModel> Changed;
    }
}