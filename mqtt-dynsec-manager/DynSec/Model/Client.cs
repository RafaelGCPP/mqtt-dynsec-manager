using mqtt_dynsec_manager.DynSec.Responses.Helpers;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Model
{

    [JsonConverter(typeof(ClientConverter))]
    public class Client
    {
        public string? UserName { get; set; }
        public string? TextName { get; set; }
        public string? TextDescription { get; set; }
        public RoleNameClass[]? Roles { get; set; }
        public GroupNameClass[]? Groups { get; set; }
    }

    public class ClientPriority
    {
        public string? UserName { get; set; }
        public int Priority { get; set; } = 1;

    }

    public class ClientNameClass
    {
        public string? UserName { get; set; }
    }

}
