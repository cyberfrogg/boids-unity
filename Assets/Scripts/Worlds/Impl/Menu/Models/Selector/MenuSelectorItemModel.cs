using System;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Models.Selector
{
    public class MenuSelectorItemModel : IModel
    {
        public event Action<IModel> Changed;
    }
}