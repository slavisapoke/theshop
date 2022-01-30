using Microsoft.Extensions.DependencyInjection;

namespace Nultien.TheShop.ServiceInitialization
{
    public class ConfigureServices
    {
        public static void Configure(IServiceCollection services)
        {
            Interfaces.Repository.Startup.Configure(services);
            Impl.Services.Startup.Configure(services);
        }
    }
}
