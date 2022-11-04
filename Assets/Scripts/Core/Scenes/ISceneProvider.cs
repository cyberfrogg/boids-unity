namespace Core.Scenes
{
    public interface ISceneProvider
    {
        IScene GetScene(int index);
        IScene GetScene(string name);
    }
}