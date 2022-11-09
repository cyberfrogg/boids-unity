using System;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Models.Selector
{
    public class MenuSelectorItemModel : IModel
    {
        public event Action<IModel> Changed;

        private string _title;
        private string _sceneName;
        
        public MenuSelectorItemModel(string title, string sceneName)
        {
            _title = title;
            _sceneName = sceneName;
        }
        
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                Changed?.Invoke(this);
            }
        }
        
        public string SceneName
        {
            get => _sceneName;
            set
            {
                _sceneName = value;
                Changed?.Invoke(this);
            }
        }
    }
}