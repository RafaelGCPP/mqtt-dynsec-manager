using mqtt_dynsec_manager.DynSecModel;
using MQTTnet;
using MQTTnet.Client;

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
            var cmds = new CommandsList(new List<AbstractCommand>        {
                        new ListClientsCommand(true),
                        new ListGroupsCommand(true),
                        new ListRolesCommand(true,-1,0)        });

            Console.Out.WriteLine(cmds.AsJSON());
            TesteAsync(cmds).Wait();
        }

        public async Task TesteAsync(CommandsList commands)
        {
            MqttFactory factory = new();
            using (IMqttClient client = factory.CreateMqttClient())
            {

                await client.ConnectAsync(options);

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
                    .WithPayload(commands.AsJSON())
                    .Build();

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


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
