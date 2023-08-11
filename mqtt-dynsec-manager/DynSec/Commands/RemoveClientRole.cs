using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public class RemoveClientRole : AbstractCommand
    {
        public RemoveClientRole(string username, string rolename) : base("removeClientRole")
        {
            UserName = username;
            RoleName = rolename;
        }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
/*
{
	"commands":[
		{
			"command": "removeClientRole",
			"username": "client to remove role from",
			"rolename": "role to remove"
		}
	]
}
 */