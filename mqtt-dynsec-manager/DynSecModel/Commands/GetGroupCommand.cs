namespace mqtt_dynsec_manager.DynSecModel
{
    public sealed class GetGroupCommand : AbstractCommand
    {
        public GetGroupCommand(string groupname) : base("getGroup") { _groupname = groupname; }
        private readonly string _groupname;
        public string Groupname { get { return _groupname; } }
    }
}
