using System;
using AwsApplicationConfig.Config;
using Microsoft.Extensions.Configuration;

namespace AwsApplicationConfig.Lambda
{
    public static class ParameterStoreConfigurationReader
    {
        private static readonly IConfigurationRoot Config;

        static ParameterStoreConfigurationReader()
        {
            var configurationBuilder = new ConfigurationBuilder()
                                      .AddEnvironmentVariables()
                                      .AddSystemsManager(
                                           configSource =>
                                           {
                                               configSource.Path = "/DotnetConfig";
                                               configSource.ReloadAfter = TimeSpan.FromMinutes(5);
                                           }
                                       );

            Config = configurationBuilder.Build();
        }

        public static ConfigModel GetConfig()
        {
            var configModel = new ConfigModel();
            Config.GetSection("ApplicationConfig").Bind(configModel);
            return configModel;
        }
    }
}
