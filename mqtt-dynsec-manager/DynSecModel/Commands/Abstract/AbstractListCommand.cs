namespace mqtt_dynsec_manager.DynSecModel.Commands.Abstract
{
    public class AbstractListCommand : AbstractCommand
    {
        public AbstractListCommand(string command) : base(command)
        {

        }

        public AbstractListCommand(string command,bool verbose) : base(command)
        {
            _verbose = verbose;
        }

        public AbstractListCommand(string command,bool verbose, int count, int offset) : base(command)
        {
            _verbose = verbose;
            _count = count;
            _offset = offset;
        }

        private readonly bool? _verbose;
        private readonly int? _count;
        private readonly int? _offset;

#pragma warning disable IDE1006 // Naming Styles
        public bool? verbose { get { return _verbose; } }
        public int? count { get { return _count; } }
        public int? offset { get { return _offset; } }
#pragma warning restore IDE1006 // Naming Styles
    }
}

