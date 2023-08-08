using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class ClientList : AbstractResponse
    {
        public class ResponseData : AbstractResponseData
        {
            public int? TotalCount { get; set; }
            public Client[]? Clients { get; set; }

        };


        public ResponseData? Data { get; set; }

    }


}
