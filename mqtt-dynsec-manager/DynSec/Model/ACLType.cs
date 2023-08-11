using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Model
{
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
