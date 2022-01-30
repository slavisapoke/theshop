using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nultien.TheShop.ServiceInitialization;
using Serilog;

namespace Nultien.TheShop.ConsoleApp
{
    public class Startup
    {
        public static IServiceCollection Configure()
        {
            var services = new ServiceCollection();

            var config = BuildConfig();

            ConfigureLogger(config);
            services.AddLogging(configure => configure.AddSerilog());

            ConfigureServices.Configure(services);

            return services;
        }

        private static void ConfigureLogger(IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(config)
               .Enrich.FromLogContext()
               .CreateLogger();
        }

        private static IConfigurationRoot BuildConfig()
        {
            var configBuilder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            return configBuilder;
        }

    }
}
