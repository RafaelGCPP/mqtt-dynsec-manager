using mqtt_dynsec_manager.DynSecModel.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSecModel
{
    public sealed class ListRolesCommand : AbstractListCommand
    {
        public ListRolesCommand() : base("listRoles") { }
        public ListRolesCommand(bool verbose) : base("listRoles", verbose) { }
        public ListRolesCommand(bool verbose, int count, int offset)
            : base("listRoles", verbose, count, offset) { }

    }
}
