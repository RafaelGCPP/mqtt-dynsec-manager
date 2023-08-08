using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Commands.Abstract
{
    [JsonDerivedType(typeof(AbstractListCommand))]

    [JsonDerivedType(typeof(SetDefaultACLAccess))]
    [JsonDerivedType(typeof(GetDefaultACLAccess))]
    [JsonDerivedType(typeof(CreateClient))]
    //DeleteClient
    //EnableClient
    //DisableClient
    [JsonDerivedType(typeof(GetClient))]
    [JsonDerivedType(typeof(ListClients))]
    [JsonDerivedType(typeof(ModifyClient))]
    [JsonDerivedType(typeof(SetClientId))]
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
        protected string _command = "";
        public string Command { get { return _command; } protected set { _command = value; } }


    }
}
