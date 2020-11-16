using System;
using System.Threading.Tasks;
using AwsApplicationConfig.Config;
using AwsApplicationConfig.Config.AwsAppConfig;

namespace AwsApplicationConfig.Lambda.Functions
{
    public class GetConfigUsingExtensionLambda
    {
        public async Task<ConfigModel> Invoke()
        {
            var appConfigConfig = AwsAppConfigConfigurationReader.GetConfiguration();
            int.TryParse(Environment.GetEnvironmentVariable("AWS_APPCONFIG_EXTENSION_HTTP_PORT"), out var port);

            using var configReader = new AwsAppConfigLambdaExtensionReader(appConfigConfig, port);

            return await configReader.GetConfigAsync();
        }
    }
}
