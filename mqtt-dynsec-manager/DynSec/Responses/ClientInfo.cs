using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class ClientInfo : AbstractResponse
    {
        public class ResponseData : AbstractResponseData
        {
            public Client? Client { get; set; }
        }


        public ResponseData? Data { get; set; }
    }
}
