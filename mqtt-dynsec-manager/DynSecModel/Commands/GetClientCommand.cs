namespace mqtt_dynsec_manager.DynSecModel
{
    public sealed class GetClientCommand : AbstractCommand
    {
        public GetClientCommand(string username) : base("getClient") { _username = username; }
        private readonly string _username;
        public string Username { get { return _username; } }
    }
}
