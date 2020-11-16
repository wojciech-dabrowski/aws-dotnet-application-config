namespace AwsApplicationConfig.Config
{
    public class ConfigModel
    {
        public string ConnectionString { get; set; }
        public bool FeatureFlag { get; set; }
        public int ConfigNumber { get; set; }
        public InnerConfigModel InnerConfig { get; set; }
    }
}
