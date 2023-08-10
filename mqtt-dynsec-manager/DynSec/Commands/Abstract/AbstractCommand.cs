using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Commands.Abstract
{
    [JsonDerivedType(typeof(AbstractListCommand))]

    [JsonDerivedType(typeof(SetDefaultACLAccess))]
    [JsonDerivedType(typeof(GetDefaultACLAccess))]
    [JsonDerivedType(typeof(CreateClient))]
    [JsonDerivedType(typeof(DeleteClient))]
    [JsonDerivedType(typeof(EnableClient))]
    [JsonDerivedType(typeof(DisableClient))]
    [JsonDerivedType(typeof(GetClient))]
    [JsonDerivedType(typeof(ListClients))]
    [JsonDerivedType(typeof(ModifyClient))]
    [JsonDerivedType(typeof(SetClientId))]
    //SetClientPassword
    //AddClientRole
    //RemoveClientRole
    //AddGroupClient
    [JsonDerivedType(typeof(CreateGroup))]
    [JsonDerivedType(typeof(DeleteGroup))]
    [JsonDerivedType(typeof(GetGroup))]
    [JsonDerivedType(typeof(ListGroups))]
    [JsonDerivedType(typeof(ModifyGroup))]
    //RemoveGroupClient
    //AddGroupRole
    //RemoveGroupRole
    //SetAnonymousGroup
    [JsonDerivedType(typeof(GetAnonymousGroup))]
    [JsonDerivedType(typeof(CreateRole))]
    [JsonDerivedType(typeof(GetRole))]
    [JsonDerivedType(typeof(ListRoles))]
    [JsonDerivedType(typeof(ModifyRole))]
    [JsonDerivedType(typeof(DeleteRole))]
    //AddRoleACL
    //RemoveRoleACL  
    public abstract class AbstractCommand
    {
        public AbstractCommand(string command) { _command = command; }
        private readonly string _command = "";
        public string Command { get { return _command; } }


    }
}
