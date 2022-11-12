using UnityEngine.UIElements;

namespace Editor.Framework
{
    public class MvpCreatorUnitVisualElement
    {
        private readonly string _path;
        private readonly string _name;

        public MvpCreatorUnitVisualElement(string path, string name)
        {
            _path = path;
            _name = name;
        }

        public void Draw(ScrollView scrollView)
        {
            var nameLabel = new Label(_name);
            scrollView.Add(nameLabel);
            var pathLabel = new Label(_path);
            scrollView.Add(pathLabel);
            var space = new Box();
            scrollView.Add(space);
        }
    }
}