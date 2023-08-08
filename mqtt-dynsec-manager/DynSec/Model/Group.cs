using mqtt_dynsec_manager.DynSec.Responses.Helpers;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Model
{
    [JsonConverter(typeof(GroupConverter))]
    public class Group
    {
        public string? GroupName { get; set; }
        public string? TextName { get; set; }
        public string? TextDescription { get; set; }
        public RoleNameClass[]? Roles { get; set; }
        public ClientNameClass[]? Clients { get; set; }
    }
    public class GroupPriority
    {
        public string? GroupName { get; set; }
        public int Priority { get; set; } = 1;

    }

    public class GroupNameClass
    {
        public string? GroupName { get; set; }
    }
}
