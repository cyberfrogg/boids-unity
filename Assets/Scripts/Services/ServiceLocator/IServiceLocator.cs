namespace Services.ServiceLocator
{
    public interface IServiceLocator
    {
        T GetService<T>() where T : IService;
    }
}