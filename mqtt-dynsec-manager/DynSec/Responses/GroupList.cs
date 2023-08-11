using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public class GroupList : AbstractResponse
    {
        public class GroupListData
        {
            public int? TotalCount { get; set; }
            public Group[]? Groups { get; set; }
        }
        public GroupListData? Data { get; set; }
    }
}
