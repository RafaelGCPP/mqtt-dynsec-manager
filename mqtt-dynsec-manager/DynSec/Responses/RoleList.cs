using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class RoleList : AbstractResponse
    {

        public RoleListData? Data { get; set; }
    }

    public sealed class RoleListData
    {
        public int? TotalCount { get; set; }
        public RoleACL[]? Roles { get; set; }

    };
}
