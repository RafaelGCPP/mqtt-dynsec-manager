using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class ClientInfo : AbstractResponse
    {
        public class ClientInfoData 
        {
            public Client? Client { get; set; }
        }


        public ClientInfoData? Data { get; set; }
    }
}
