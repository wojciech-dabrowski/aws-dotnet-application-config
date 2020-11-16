using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace AwsApplicationConfig.Config
{
    public class AwsAppConfigReader
    {
        private readonly string _applicationId;
        private readonly string _environmentId;
        private readonly string _clientId;
        private readonly string _configurationProfileId;
        private readonly IAmazonAppConfig _appConfigClient;

        public AwsAppConfigReader(string applicationId, string environmentId, string clientId, string configurationProfileId, IAmazonAppConfig appConfigClient = null)
        {
            _applicationId = applicationId;
            _environmentId = environmentId;
            _clientId = clientId;
            _configurationProfileId = configurationProfileId;
            _appConfigClient = appConfigClient ?? new AmazonAppConfigClient();
        }

        public async Task<ConfigModel> GetConfig()
        {
            var request = new GetConfigurationRequest
            {
                Application = _applicationId,
                Environment = _environmentId,
                ClientId = _clientId,
                Configuration = _configurationProfileId
            };

            var response = await _appConfigClient.GetConfigurationAsync(request);
            using var sr = new StreamReader(response.Content);
            var content = await sr.ReadToEndAsync();
            var rootConfig = JsonSerializer.Deserialize<RootConfigModel>(content);
            return rootConfig.ApplicationConfig;
        }
    }
}
