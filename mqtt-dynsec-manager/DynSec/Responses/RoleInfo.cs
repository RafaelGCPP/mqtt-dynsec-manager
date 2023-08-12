using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class RoleInfo : AbstractResponse
    {
        public RoleInfoData? Data { get; set; }
    }
    
    public class RoleInfoData : AbstractResponseData
    {
        public RoleACL? Role { get; set; }
    }
}


