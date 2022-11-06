namespace Services.Scenes.SceneProvider
{
    public interface ISceneProvider : IService
    {
        IScene GetScene(int index);
        IScene GetScene(string name);
    }
}