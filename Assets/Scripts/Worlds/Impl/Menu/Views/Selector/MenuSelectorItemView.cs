using TMPro;
using UnityEngine;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Views.Selector
{
    public class MenuSelectorItemView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshPro _titleText;

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
    }
}