using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Commands.Abstract
{
    [JsonDerivedType(typeof(AbstractListCommand))]

    [JsonDerivedType(typeof(SetDefaultACLAccess))]
    [JsonDerivedType(typeof(GetDefaultACLAccess))]
    //CreateClient
    //DeleteClient
    //EnableClient
    //DisableClient
    [JsonDerivedType(typeof(GetClient))]
    [JsonDerivedType(typeof(ListClients))]
    //ModifyClient
    //SetClientID
    //SetClientPassword
    //AddClientRole
    //RemoveClientRole
    //AddGroupClient
    //CreateGroup
    //DeleteGroup
    [JsonDerivedType(typeof(GetGroup))]
    [JsonDerivedType(typeof(ListGroups))]
    //ModifyGroup
    //RemoveGroupClient
    //AddGroupRole
    //RemoveGroupRole
    //SetAnonymousGroup
    //GetAnonymousGroup
    //CreateRole
    //GetRole
    [JsonDerivedType(typeof(ListRoles))]
    //ModifyRole
    //DeleteRole
    //AddRoleACL
    //RemoveRoleACL  
    public abstract class AbstractCommand
    {
        public AbstractCommand(string command) { _command = command; }
        private readonly string _command = "";
        public string Command { get { return _command; } }


    }
}
