using UnityEngine;
using Worlds.Abstracts;

namespace Worlds.Impl.Menu.Views.Selector
{
    public class MenuSelectorView : MonoBehaviour, IView
    {
        [SerializeField] private int _debug;

        public void OnSelectedLevelIndexChanged(int index)
        {
            _debug = index;
        }
    }
}