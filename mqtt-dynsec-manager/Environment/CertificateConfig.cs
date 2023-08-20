namespace mqtt_dynsec_manager.Environment
{
    public class CertificateConfig
    {
        public string Path { get; set; } = "mqtt-dynsec-manager.pfx";
        public string? Password { get; set; }
    }
}
