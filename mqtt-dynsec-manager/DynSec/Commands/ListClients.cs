using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class ListClients : AbstractListCommand
    {
        public ListClients() : base("listClients") { }
        public ListClients(bool verbose) : base("listClients", verbose) { }
        public ListClients(bool verbose, int count, int offset)
            : base("listClients", verbose, count, offset) { }
    }
}
