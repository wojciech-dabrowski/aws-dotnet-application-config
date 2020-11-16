using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AwsApplicationConfig.WebApp
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                    // .ConfigureAppConfiguration(
                    //      builder =>
                    //      {
                    //          builder.AddSystemsManager(
                    //              configureSource =>
                    //              {
                    //                  configureSource.Path = "/DotnetConfig";
                    //                  configureSource.ReloadAfter = TimeSpan.FromMinutes(5);
                    //              }
                    //          );
                    //      }
                    //  )
                   .ConfigureWebHostDefaults(
                        webBuilder =>
                        {
                            webBuilder.UseStartup<Startup>();
                        }
                    );
    }
}
