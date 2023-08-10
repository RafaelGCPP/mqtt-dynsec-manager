using mqtt_dynsec_manager.DynSec.Converters;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Model
{
    [JsonConverter(typeof(RoleACLConverter))]
    public class RoleACL
    {
        public string? RoleName { get; set; }
        public string? TextName { get; set; }
        public string? TextDescription { get; set; }

        public ACLDefinition[]? ACLs { get; set; }

    }

    public class RolePriority
    {
        public string? RoleName { get; set; }
        public int Priority { get; set; } = 1;

    }

    public class RoleNameClass
    {
        public string? RoleName { get; set; }
    }
}
