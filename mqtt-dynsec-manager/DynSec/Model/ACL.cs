namespace mqtt_dynsec_manager.DynSec.Model
{
    public class DefaultACL
    {
        public string? ACLType { get; set; }
        public bool? Allow { get; set; }
    }

    public class ACLDefinition
    {
        public string? ACLType { get; set; }
        public string? Topic { get; set; }
        public int? Priority { get; set; }
        public bool? Allow { get; set; }
    }

}
