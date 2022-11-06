namespace Worlds.Abstracts
{
    public abstract class ControllerBase<T> where T : ViewBase
    {
        public T View { get; set; }
    }
}