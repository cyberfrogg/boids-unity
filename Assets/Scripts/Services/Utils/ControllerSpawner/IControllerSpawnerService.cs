using Worlds.Abstracts;

namespace Services.Utils.ControllerSpawner
{
    public interface IControllerSpawnerService : IService
    {
        T Spawn<T, T2>() where T : ControllerBase<ViewBase>, new();
        
        // T - SampleController<SampleView>
        // .Spawn<SampleController<SampleView>>();
    }
}