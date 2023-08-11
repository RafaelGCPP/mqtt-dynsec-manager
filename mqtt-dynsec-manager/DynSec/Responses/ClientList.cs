using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class ClientList : AbstractResponse
    {



        public ClientListData? Data { get; set; }

    }

    public sealed class ClientListData : AbstractResponseData
    {
        public int? TotalCount { get; set; }
        public Client[]? Clients { get; set; }

    };


}
