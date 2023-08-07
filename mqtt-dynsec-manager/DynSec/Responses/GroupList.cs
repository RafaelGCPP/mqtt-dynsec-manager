using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class GroupList:AbstractResponse
    {
        public object? Data { get; set; }
    }
}
