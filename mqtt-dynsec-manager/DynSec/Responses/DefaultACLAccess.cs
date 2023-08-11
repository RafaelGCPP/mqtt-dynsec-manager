using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class DefaultACLAccess : AbstractResponse
    {
        public class DefaultACLAccessData 
        {
            public DefaultACL[]? ACLs { get; set; }
        }
        public DefaultACLAccessData? Data { get; set; }
    }
}
