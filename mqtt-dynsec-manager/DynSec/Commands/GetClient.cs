using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public sealed class GetClient : AbstractCommand
    {
        public GetClient(string username) : base("getClient") { _username = username; }
        private readonly string _username;
        public string Username { get { return _username; } }
    }
}
