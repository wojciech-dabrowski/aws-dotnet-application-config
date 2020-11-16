using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AwsApplicationConfig.Config;
using AwsApplicationConfig.Config.AwsAppConfig;

namespace AwsApplicationConfig.Lambda
{
    public class AwsAppConfigLambdaExtensionReader : IDisposable
    {
        private const int DefaultPort = 2772;
        private readonly string _getConfigUrl;
        private readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>();

        public AwsAppConfigLambdaExtensionReader(AwsAppConfigConfiguration appConfigConfig, int port = DefaultPort)
        {
            port = port > 0
                       ? port
                       : DefaultPort;

            _getConfigUrl =
                $"http://localhost:{port}/"
              + $"applications/{appConfigConfig.ApplicationId}/"
              + $"environments/{appConfigConfig.EnvironmentId}/"
              + $"configurations/{appConfigConfig.ConfigProfileId}";
        }

        public void Dispose()
        {
            if (_httpClient.IsValueCreated)
            {
                _httpClient.Value.Dispose();
            }
        }

        public async Task<ConfigModel> GetConfigAsync()
        {
            var result = await _httpClient.Value.GetAsync(_getConfigUrl);
            var content = await result.Content.ReadAsStringAsync();
            var rootConfig = JsonSerializer.Deserialize<RootConfigModel>(content);
            return rootConfig.ApplicationConfig;
        }
    }
}
