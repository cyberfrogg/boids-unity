namespace Boids.Context.Contexts
{
    public interface IContext
    {
        bool IsEnabled { get; set; }
        EContextType Type { get; }
    }
}