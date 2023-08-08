using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class ListGroups : AbstractListCommand
    {
        public ListGroups() : base("listGroups") { }
        public ListGroups(bool? verbose = false, int? count = null, int? offset = null)
            : base("listGroups", verbose, count, offset) { }

    }
}
