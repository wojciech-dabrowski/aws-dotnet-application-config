namespace AwsApplicationConfig.Config.AwsAppConfig
{
    public class AwsAppConfigConfiguration
    {
        public AwsAppConfigConfiguration(string applicationId, string configProfileId, string environmentId)
        {
            ApplicationId = applicationId;
            ConfigProfileId = configProfileId;
            EnvironmentId = environmentId;
        }

        public string ApplicationId { get; }
        public string ConfigProfileId { get; }
        public string EnvironmentId { get; }
    }
}
