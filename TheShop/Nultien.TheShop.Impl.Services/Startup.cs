using Microsoft.Extensions.DependencyInjection;
using Nultien.TheShop.Interfaces.Services;

namespace Nultien.TheShop.Impl.Services
{
    public class Startup
    {
        public static void Configure(IServiceCollection svcCollection)
        {
            svcCollection.AddAutoMapper(typeof(Startup));
            svcCollection.AddSingleton<IArticleService, ArticleService>();
            svcCollection.AddSingleton<ISupplierService, SupplierService>();
            svcCollection.AddSingleton<IShopService, ShopService>();
        }
    }
}
