namespace Worlds.Bundle.Impl
{
    public class WorldObjectBundle<TC, TM, TV> : IWorldObjectBundle<TC, TM, TV>
    {
        private readonly TC _controller;
        private readonly TM _model;
        private readonly TV _view;

        public WorldObjectBundle(int uid, TC controller, TM model, TV view)
        {
            Uid = uid;
            _controller = controller;
            _model = model;
            _view = view;
        }

        public int Uid { get; private set; }
        
        public TC Controller => _controller;
        public bool HasController => _controller != null;
        
        public TM Model => _model;
        public bool HasModel => _model != null;
        
        public TV View => _view;
        public bool HasView => _view != null;
    }
}