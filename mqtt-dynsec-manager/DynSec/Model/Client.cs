using mqtt_dynsec_manager.DynSec.Converters;
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

}
