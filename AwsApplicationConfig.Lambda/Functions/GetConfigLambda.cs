using System.Threading.Tasks;
using AwsApplicationConfig.Config;
using AwsApplicationConfig.Config.AwsAppConfig;

namespace AwsApplicationConfig.Lambda.Functions
{
    public class GetConfigLambda
    {
        public async Task<ConfigModel> Invoke()
            =>
                // return GetConfigUsingParameterStore();
                await GetConfigUsingAppConfigAsync();

        private async Task<ConfigModel> GetConfigUsingAppConfigAsync()
        {
            var appConfigConfig = AwsAppConfigConfigurationReader.GetConfiguration();
            const string clientId = "GetConfigLambda";

            var appConfigReader = new AwsAppConfigProvider(appConfigConfig, clientId);
            return await appConfigReader.GetConfigAsync();
        }

        private static ConfigModel GetConfigUsingParameterStore() => ParameterStoreConfigurationReader.GetConfig();
    }
}
