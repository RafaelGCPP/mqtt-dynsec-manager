using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class DefaultACLAccess : AbstractResponse
    {
        public class ResponseData : AbstractResponseData
        {
            public DefaultACL[]? ACLs { get; set; }
        }
        public ResponseData? Data { get; set; }
    }
}
