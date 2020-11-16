using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace AwsApplicationConfig.Config.AwsAppConfig
{
    public class AwsAppConfigProvider
    {
        private readonly IAmazonAppConfig _appConfigClient;
        private readonly string _clientId;
        private readonly AwsAppConfigConfiguration _configuration;

        public AwsAppConfigProvider(AwsAppConfigConfiguration configuration, string clientId, IAmazonAppConfig appConfigClient = null)
        {
            _configuration = configuration;
            _clientId = clientId;
            _appConfigClient = appConfigClient ?? new AmazonAppConfigClient();
        }

        public async Task<ConfigModel> GetConfigAsync()
        {
            var request = new GetConfigurationRequest
            {
                Application = _configuration.ApplicationId,
                Environment = _configuration.EnvironmentId,
                ClientId = _clientId,
                Configuration = _configuration.ConfigProfileId
            };

            var response = await _appConfigClient.GetConfigurationAsync(request);
            using var sr = new StreamReader(response.Content);
            var content = await sr.ReadToEndAsync();
            var rootConfig = JsonSerializer.Deserialize<RootConfigModel>(content);
            return rootConfig.ApplicationConfig;
        }
    }
}
