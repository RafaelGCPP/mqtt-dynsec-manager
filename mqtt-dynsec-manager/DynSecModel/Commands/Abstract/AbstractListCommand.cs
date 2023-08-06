using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSecModel.Commands.Abstract
{
    [JsonDerivedType(typeof(ListClientsCommand))]
    [JsonDerivedType(typeof(ListGroupsCommand))]
    [JsonDerivedType(typeof(ListRolesCommand))]
    public class AbstractListCommand : AbstractCommand
    {
        public AbstractListCommand(string command) : base(command)
        {

        }

        public AbstractListCommand(string command, bool verbose) : base(command)
        {
            _verbose = verbose;
        }

        public AbstractListCommand(string command, bool verbose, int count, int offset) : base(command)
        {
            _verbose = verbose;
            _count = count;
            _offset = offset;
        }

        private readonly bool? _verbose;
        private readonly int? _count;
        private readonly int? _offset;

        public bool? Verbose { get { return _verbose; } }
        public int? Count { get { return _count; } }
        public int? Offset { get { return _offset; } }
    }
}

