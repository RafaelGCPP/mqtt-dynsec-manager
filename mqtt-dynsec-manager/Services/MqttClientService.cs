using mqtt_dynsec_manager.DynSecModel;
using mqtt_dynsec_manager.Helpers;
using MQTTnet;
using MQTTnet.Client;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace mqtt_dynsec_manager.Services
{
    public class MqttClientService : IDisposable
    {
        // readonly MqttFactory mqttFactory = new();
        // MqttClient client=mqttFactory.CreateMqttClient();
        MqttClientOptions options;
        private bool disposedValue;
        private const string topic = "$CONTROL/dynamic-security/v1";

        public MqttClientService(MqttClientOptions mqttOptions) { options = mqttOptions; }

        public void Teste()
        {

            TesteAsync().Wait();
        }

        public async Task TesteAsync()
        {
            MqttFactory factory = new();
            using (IMqttClient client = factory.CreateMqttClient())
            {

                await client.ConnectAsync(options);

                var cmds = new CommandsList(
                    new List<AbstractCommand>
                        {
                        new ListClientsCommand(true),
                        new ListGroupsCommand(true),
                        new ListRolesCommand(true,-1,0),
                        }
                );


                var jsonoptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
                };
                string json = JsonSerializer.Serialize(cmds, jsonoptions);

                json.DumpToConsole();

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
                    .WithPayload(json)
                    .Build();

                message.DumpToConsole();

                await client.PublishAsync(message);

            }



        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MqttClientService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
