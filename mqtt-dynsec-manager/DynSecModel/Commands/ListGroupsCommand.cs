using mqtt_dynsec_manager.DynSecModel.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSecModel
{
    public sealed class ListGroupsCommand : AbstractListCommand
    {
        public ListGroupsCommand() : base("listGroups") { }
        public ListGroupsCommand(bool verbose) : base("listGroups", verbose) { }
        public ListGroupsCommand(bool verbose, int count, int offset)
            : base("listGroups", verbose, count, offset) { }

    }
}
