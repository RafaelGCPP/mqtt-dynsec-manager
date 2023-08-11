using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Responses.Abstract
{
    [JsonDerivedType(typeof(AnonymousGroupInfoData))]
    [JsonDerivedType(typeof(ClientInfoData))]
    [JsonDerivedType(typeof(ClientListData))]
    [JsonDerivedType(typeof(GroupInfoData))]
    [JsonDerivedType(typeof(GroupListData))]
    [JsonDerivedType(typeof(RoleListData))]
    public abstract class AbstractResponseData
    {
    }
}
