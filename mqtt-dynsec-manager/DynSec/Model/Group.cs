namespace mqtt_dynsec_manager.DynSec.Model
{
    public class ClientGroup
    {
        public string? RoleName { get; set; }
        public int Priority { get; set; } = 1;

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
