using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class AnonymousGroupInfo : AbstractResponse
    {
        public class ResponseData : AbstractResponseData
        {
            public GroupNameClass? group { get; set; }
        }
        public ResponseData? data { get; set; }
    }
}
