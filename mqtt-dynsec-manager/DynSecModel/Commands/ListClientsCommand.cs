using mqtt_dynsec_manager.DynSecModel.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSecModel
{
    public sealed class ListClientsCommand : AbstractListCommand
    {
        public ListClientsCommand() : base("listClients") { }
        public ListClientsCommand(bool verbose) : base("listClients", verbose) { }
        public ListClientsCommand(bool verbose, int count, int offset)
            : base("listClients", verbose, count, offset) { }
    }
}
