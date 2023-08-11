using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public class SetAnonymousGroup : AbstractCommand
    {
        public SetAnonymousGroup(string groupname) : base("setAnonymousGroup")
        {
            GroupName = groupname;
        }
        public string GroupName { get; set; }
    }
}
/*
{
	"commands":[
		{
			"command": "setAnonymousGroup",
			"groupname": "group"
		}
	]
}
 */