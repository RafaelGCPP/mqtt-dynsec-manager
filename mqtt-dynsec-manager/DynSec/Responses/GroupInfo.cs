using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class GroupInfo : AbstractResponse
    {
        public class ResponseData
        {
            public Group? Group { get; set; }
        }
        public class Group
        {
            public string? GroupName { get; set; }
            public RoleNameClass[]? Roles { get; set; }
            public ClientNameClass[]? Clients { get; set; }
        }

        public ResponseData? Data { get; set; }
    }
}
