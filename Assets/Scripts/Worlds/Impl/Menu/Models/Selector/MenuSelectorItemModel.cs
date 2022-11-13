using UnityEngine;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Models.Selector
{
    public class MenuSelectorItemModel : AGameObjectModel
    {
        private string _title;
        private string _sceneName;
        private float _width;
        private Vector3 _position;
        
        public MenuSelectorItemModel(string title, string sceneName, float width = 2f)
        {
            _title = title;
            _sceneName = sceneName;
            _width = width;
        }
        
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                InvokeChanged();
            }
        }
        
        public string SceneName
        {
            get => _sceneName;
            set
            {
                _sceneName = value;
                InvokeChanged();
            }
        }

        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                InvokeChanged();
            }
        }
    }
}