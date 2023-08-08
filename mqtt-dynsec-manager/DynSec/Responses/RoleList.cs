using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class RoleList : AbstractResponse
    {
        public class ResponseData : AbstractResponseData
        {
            public int? TotalCount { get; set; }
            public RoleACL[]? Roles { get; set; }

        };
        public ResponseData? Data { get; set; }
    }
}
