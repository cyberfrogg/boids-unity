namespace Services.UidGenerator.Impl
{
    public class UidGenerator : IUidGenerator
    {
        private int _lastUid;
        
        public int Next()
        {
            _lastUid++;
            return _lastUid;
        }
    }
}