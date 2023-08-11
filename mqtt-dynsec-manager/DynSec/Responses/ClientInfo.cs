using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class ClientInfo : AbstractResponse
    {
        public ClientInfoData? Data { get; set; }
    }

    public sealed class ClientInfoData : AbstractResponseData
    {
        public Client? Client { get; set; }
    }
}
