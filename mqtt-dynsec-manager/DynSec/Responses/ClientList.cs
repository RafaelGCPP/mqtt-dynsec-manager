using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;
using System.Data;
using static mqtt_dynsec_manager.DynSec.Responses.ClientList;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class ClientList : AbstractResponse
    {
        public class ResponseData
        {
            public int? TotalCount { get; set; }
            public Client[]? Clients { get; set; }

        };

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
