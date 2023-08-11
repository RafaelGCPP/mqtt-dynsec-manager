using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class GroupList : AbstractResponse
    {

        public GroupListData? Data { get; set; }
    }
    public sealed class GroupListData : AbstractResponseData
    {
        public int? TotalCount { get; set; }
        public Group[]? Groups { get; set; }
    }
}
