namespace Services.Scenes.Impl
{
    public class Scene : IScene
    {
        public int Index { get; }
        public string Name { get; }

        public Scene(int index, string name)
        {
            Index = index;
            Name = name;
        }
    }
}