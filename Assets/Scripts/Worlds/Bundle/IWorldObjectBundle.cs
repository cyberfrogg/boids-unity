namespace Worlds.Bundle
{
    public interface IWorldObjectBundle<TC, TM, TV>
    {
        int Uid { get; }
        TC Controller { get; }
        bool HasController { get; }
        TM Model { get; }
        bool HasModel { get; }
        TV View { get; }
        bool HasView { get; }
    }
}