using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class GetRole : AbstractCommand
    {
        public GetRole(string rolename) : base("getRole") { _rolename = rolename; }
        private readonly string _rolename;
        public string RoleName { get { return _rolename; } }
    }
}
