namespace mqtt_dynsec_manager.Environment
{
    public class OracleDBConfig
    {
        public string? UserName { set; get; }
        public string? Password { set; get; }
        public string? DataSource { set; get; }

        public string ConnectionString
        {
            get
            {
                return $"User Id={UserName}; Password={Password}; Data Source={DataSource}";
            }
        }
    }
}
