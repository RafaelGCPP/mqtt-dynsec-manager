namespace mqtt_dynsec_manager.DynSecModel
{
    public class GetClientCommand:AbstractCommand
    {
        public GetClientCommand(string username) : base("getClient") { _username = username; }
        private string _username;
        public string username { get { return _username; }  }
    }
}
