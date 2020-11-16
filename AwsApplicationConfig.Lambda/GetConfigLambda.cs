using AwsApplicationConfig.Config;

namespace AwsApplicationConfig.Lambda
{
    public class GetConfigLambda
    {
        public ConfigModel Invoke() => ConfigurationReader.GetConfig();
    }
}
