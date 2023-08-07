using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Model;

namespace mqtt_dynsec_manager.DynSec.Commands
{


    public class SetDefaultACLAccess : AbstractCommand
    {
        public SetDefaultACLAccess() : base("setDefaultACLAccess") { }
        public SetDefaultACLAccess(List<DefaultACL> _ACLs) : base("setDefaultACLAccess") { ACLs = _ACLs; }

        public List<DefaultACL> ACLs { get; set; } = new List<DefaultACL>();

    }


}
