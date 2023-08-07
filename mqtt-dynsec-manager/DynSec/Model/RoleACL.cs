namespace mqtt_dynsec_manager.DynSec.Model
{
    public class RoleACL
    {
        public string? ACLType { get; set; }
        public string? Topic { get; set; }
        public int? Priority { get; set; }
        public bool? Allow { get; set; }
    }

}
