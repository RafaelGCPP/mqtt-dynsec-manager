using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class ListClients : AbstractListCommand
    {
        public ListClients() : base("listClients") { }
        public ListClients(bool verbose = false, int? count = null, int? offset = null)
            : base("listClients", verbose, count, offset) { }
    }
}
