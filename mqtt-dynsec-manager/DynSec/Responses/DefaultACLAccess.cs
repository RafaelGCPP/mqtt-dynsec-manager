using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class DefaultACLAccess : AbstractResponse
    {

        public DefaultACLAccessData? Data { get; set; }
    }
    public sealed class DefaultACLAccessData : AbstractResponseData
    {
        public DefaultACL[]? ACLs { get; set; }
    }
}
