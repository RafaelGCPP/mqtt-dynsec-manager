namespace mqtt_dynsec_manager.Environment
{
    public class MQTTConfig
    {
        public string? Host { get; set; }
        public int Port { get; set; } = 8883;
        public bool Tls { get; set; } = true;
        public bool WebSockets { get; set; } = false;
        public string? UserName { get; set; }
        public string? Password { get; set; }


    }
}
