namespace Boids.World.Services.UidGenerator.Impl
{
    public class UidGenerator : IUidGenerator
    {
        private int _lastUid = 0;
        
        public int Next()
        {
            _lastUid++;
            return _lastUid;
        }
    }
}