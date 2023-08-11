using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class GroupInfo : AbstractResponse
    {


        public GroupInfoData? Data { get; set; }
    }

    public sealed class GroupInfoData : AbstractResponseData
    {
        public Group? Group { get; set; }
    }
}
