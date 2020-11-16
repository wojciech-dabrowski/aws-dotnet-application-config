using System;
using System.Threading.Tasks;
using AwsApplicationConfig.Config;

namespace AwsApplicationConfig.Lambda
{
    public class GetConfigLambda
    {
        public async Task<ConfigModel> Invoke()
        {
            // return GetConfigUsingParameterStore();

            return await GetConfigUsingAppConfigAsync();
        }

        private async Task<ConfigModel> GetConfigUsingAppConfigAsync()
        {
            var appConfigAppId = Environment.GetEnvironmentVariable("APP_CONFIG_APP_ID");
            var appConfigEnvironmentId = Environment.GetEnvironmentVariable("APP_CONFIG_ENVIRONMENT_ID");
            var appConfigConfigProfileId = Environment.GetEnvironmentVariable("APP_CONFIG_CONFIG_PROFILE_ID");
            const string clientId = "GetConfigLambda";

            var appConfigReader = new AwsAppConfigReader(appConfigAppId, appConfigEnvironmentId, clientId, appConfigConfigProfileId);
            return await appConfigReader.GetConfig();
        }

        private static ConfigModel GetConfigUsingParameterStore() => ConfigurationReader.GetConfig();
    }
}
