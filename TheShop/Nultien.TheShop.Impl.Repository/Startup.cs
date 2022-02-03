using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nultien.TheShop.Impl.Repository;

namespace Nultien.TheShop.Interfaces.Repository
{
    public class Startup
    {
        public static void Configure(IServiceCollection svcCollection)
        {
            svcCollection.AddDbContext<ShopDbContext>(options => options.UseInMemoryDatabase("ShopTestDbContext"));
            svcCollection.AddSingleton<IArticleRepository, ArticleRepository>();
            svcCollection.AddSingleton<ISupplierRepository, SupplierRepository>();
            svcCollection.AddSingleton<ISupplierArticleRepository, SupplierArticleRepository>();
        }
    }
}
