namespace Services.UidGenerator
{
    public interface IUidGenerator : IService
    {
        int Next();
    }
}