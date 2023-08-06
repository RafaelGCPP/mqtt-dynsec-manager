using mqtt_dynsec_manager.DynSecModel.Commands.Abstract;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSecModel
{
    [JsonDerivedType(typeof(AbstractListCommand))]
    [JsonDerivedType(typeof(ListClientsCommand))]
    [JsonDerivedType(typeof(ListGroupsCommand))]
    [JsonDerivedType(typeof(ListRolesCommand))]
    [JsonDerivedType(typeof(GetDefaultACLAccessCommand))]
    [JsonDerivedType(typeof(GetClientCommand))]
    [JsonDerivedType(typeof(GetGroupCommand))]
    public abstract class AbstractCommand
    {
        public AbstractCommand(string command) { _command = command; }
        private readonly string _command = "";
        public string Command { get { return _command; } }


    }
}
