using IdentityModel.Client;
using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class ClientInfo:AbstractResponse
    {
        public class ResponseData
        {
            public Client? Client { get; set; }
        }
        public class Client
        {
            public string? UserName { get; set; }
            public string? TextName { get; set; }
            public RoleNameClass[]? Roles { get; set; }
            public GroupNameClass[]? Groups { get; set; }
        }
 
        public ResponseData? Data { get; set; }
    }
}
