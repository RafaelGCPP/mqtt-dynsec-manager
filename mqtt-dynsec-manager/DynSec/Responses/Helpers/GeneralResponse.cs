using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses.Helpers
{
    public class GeneralResponse : AbstractResponse
    {
        public object? Data { get; set; }
    }
}
