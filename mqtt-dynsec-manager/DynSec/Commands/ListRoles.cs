using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class ListRoles : AbstractListCommand
    {
        public ListRoles() : base("listRoles") { }
        public ListRoles(bool verbose) : base("listRoles", verbose) { }
        public ListRoles(bool verbose, int count, int offset)
            : base("listRoles", verbose, count, offset) { }

    }
}
