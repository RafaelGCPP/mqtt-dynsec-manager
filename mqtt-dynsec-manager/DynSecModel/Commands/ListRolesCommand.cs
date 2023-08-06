namespace mqtt_dynsec_manager.DynSecModel
{
    public class ListRolesCommand : AbstractCommand
    {
        public ListRolesCommand() : base("listRoles")
        {

        }

        public ListRolesCommand(bool verbose) : base("listRoles")
        {
            _verbose = verbose;
        }

        public ListRolesCommand(bool verbose, int count, int offset) : base("listRoles")
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
