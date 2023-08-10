using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public class DeleteRole : AbstractCommand
    {
        public DeleteRole(string rolename) : base("deleteRole") { _rolename = rolename; }
        private readonly string _rolename;
        public string RoleName { get { return _rolename; } }
    }
}
