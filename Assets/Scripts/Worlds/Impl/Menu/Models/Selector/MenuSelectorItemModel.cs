using System;
using UnityEngine;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Models.Selector
{
    public class MenuSelectorItemModel : IModel
    {
        public event Action<IModel> Changed;

        private string _title;
        private string _sceneName;
        private float _width;
        private Vector3 _position;
        
        public MenuSelectorItemModel(string title, string sceneName, float width)
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

        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                Changed?.Invoke(this);
            }
        }

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                Changed?.Invoke(this);
            }
        }
    }
}