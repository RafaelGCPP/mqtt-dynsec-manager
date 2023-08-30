using mqtt_dynsec_manager.Environment;
using MQTTnet;
using MQTTnet.Client;

namespace mqtt_dynsec_manager.Helpers
{
    internal static class MqttServicesExtension
    {
        public static void AddMqttOptions(this IServiceCollection services, MQTTConfig mqttConfig)
        {
            MqttClientOptionsBuilder mqttClientOptionsBuilder = new();
            if (mqttConfig.WebSockets)
            {
                mqttClientOptionsBuilder = mqttClientOptionsBuilder.WithWebSocketServer(mqttConfig.Host)
                    .WithCredentials(mqttConfig.UserName, mqttConfig.Password);
            }
            else
            {
                mqttClientOptionsBuilder = mqttClientOptionsBuilder.WithTcpServer(mqttConfig.Host)
                    .WithCredentials(mqttConfig.UserName, mqttConfig.Password); ;
            }

            if (mqttConfig.Tls) mqttClientOptionsBuilder = mqttClientOptionsBuilder.WithTls();
            var mqttClientOptions = mqttClientOptionsBuilder
                .WithClientId("mqtt-dynsec-manager")
                .WithCleanSession(true)
                .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
                .WithNoKeepAlive()                
                .Build();

            services.AddSingleton(mqttClientOptions);
        }

        public static void AddMqttClient(this IServiceCollection services)
        {
            services.AddSingleton<IMqttClient>(sp =>
            {
                MqttFactory mqttFactory = new();
                var client = mqttFactory.CreateMqttClient();              
                return client;
            });
        }
    }
}
