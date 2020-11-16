using System;

namespace AwsApplicationConfig.Config.AwsAppConfig
{
    public static class AwsAppConfigConfigurationReader
    {
        public static AwsAppConfigConfiguration GetConfiguration()
            => new AwsAppConfigConfiguration(
                Environment.GetEnvironmentVariable("APP_CONFIG_APP_ID")!,
                Environment.GetEnvironmentVariable("APP_CONFIG_CONFIG_PROFILE_ID")!,
                Environment.GetEnvironmentVariable("APP_CONFIG_ENVIRONMENT_ID")!
            );
    }
}
