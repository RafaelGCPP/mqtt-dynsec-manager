using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Model
{
    public class DefaultACL
    {
        public ACLType? ACLType { get; set; }
        public bool? Allow { get; set; }
    }

    public class ACLDefinition
    {
        public ACLType? ACLType { get; set; }
        public string? Topic { get; set; }
        public int? Priority { get; set; }
        public bool? Allow { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ACLType
    {
        publishClientSend, 
        publishClientReceive, 
        subscribeLiteral, 
        subscribePattern, 
        unsubscribeLiteral, 
        unsubscribePattern
    }

}
