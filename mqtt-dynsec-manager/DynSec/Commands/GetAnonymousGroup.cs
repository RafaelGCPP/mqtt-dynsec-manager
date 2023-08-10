using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public class GetAnonymousGroup : AbstractCommand
    {
        public GetAnonymousGroup() : base("getAnonymousGroup") { }
    }
}
