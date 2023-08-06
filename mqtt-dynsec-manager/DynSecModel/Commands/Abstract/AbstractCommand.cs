using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSecModel
{
    [JsonDerivedType(typeof(ListClientsCommand))]
    [JsonDerivedType(typeof(ListGroupsCommand))]
    [JsonDerivedType(typeof(ListRolesCommand))]
    [JsonDerivedType(typeof(GetDefaultACLAccessCommand))]
    [JsonDerivedType(typeof(GetClientCommand))]
    [JsonDerivedType(typeof(GetGroupCommand))]
    public abstract class AbstractCommand 
    {
        public AbstractCommand(string command) { _command = command; }
        private string _command = "";
        public string command { get { return _command;} }

       
    }
}
