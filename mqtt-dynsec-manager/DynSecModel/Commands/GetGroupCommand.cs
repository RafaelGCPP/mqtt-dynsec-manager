namespace mqtt_dynsec_manager.DynSecModel
{
    public class GetGroupCommand:AbstractCommand
    {
        public GetGroupCommand(string groupname) : base("getGroup") { _groupname = groupname; }
        private string _groupname;
        public string groupname { get { return _groupname; } }
    }
}
