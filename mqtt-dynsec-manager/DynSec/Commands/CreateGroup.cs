using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Commands.Helpers;
using mqtt_dynsec_manager.DynSec.Model;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public class CreateGroup : AbstractCommand
    {
        public CreateGroup(string _groupname) : base("createGroup")
        {
            GroupName = _groupname;
        }
        public string GroupName { get; set; }
        public List<RolePriority>? Roles { get; set; }

    }
    public class CreateGroupBuilder : CMGroupBuilder
    {
        private readonly CreateGroup createGroup;
        public CreateGroupBuilder(string _groupname) : base(_groupname)
        {
            createGroup = new CreateGroup(_groupname);
        }

        public override CreateGroup Build()
        {
            createGroup.Roles = Roles;
            createGroup.GroupName = groupname;

            return createGroup;
        }
    }
}
