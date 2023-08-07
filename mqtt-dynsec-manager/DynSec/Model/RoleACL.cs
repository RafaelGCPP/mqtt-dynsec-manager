namespace mqtt_dynsec_manager.DynSec.Model
{
    public class RoleACL
    {
        public string? RoleName { get; set; }
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
