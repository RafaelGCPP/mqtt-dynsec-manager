namespace mqtt_dynsec_manager.DynSec.Model
{
    public class Role
    {
        public string? RoleName { get; set; }
        public RoleACL[]? ACLs { get; set; }

    }
}
