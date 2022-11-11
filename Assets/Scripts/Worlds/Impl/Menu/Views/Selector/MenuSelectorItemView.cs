using TMPro;
using UnityEngine;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Views.Selector
{
    public class MenuSelectorItemView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshPro _titleText;
        [SerializeField] private float _width;

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                _titleText.text = value;
            }
        }

        public float Width
        {
            get => _width;
            set => _width = value;
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}