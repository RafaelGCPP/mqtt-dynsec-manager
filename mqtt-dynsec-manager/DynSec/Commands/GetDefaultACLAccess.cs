using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class GetDefaultACLAccess : AbstractCommand
    {
        public GetDefaultACLAccess() : base("getDefaultACLAccess") { }
    }
}
