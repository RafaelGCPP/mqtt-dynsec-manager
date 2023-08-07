using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class ListGroups : AbstractListCommand
    {
        public ListGroups() : base("listGroups") { }
        public ListGroups(bool verbose) : base("listGroups", verbose) { }
        public ListGroups(bool verbose, int count, int offset)
            : base("listGroups", verbose, count, offset) { }

    }
}
