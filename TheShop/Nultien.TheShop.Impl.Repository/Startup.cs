using Microsoft.Extensions.DependencyInjection;
using Nultien.TheShop.Impl.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Interfaces.Repository
{
    public class Startup
    {
        public static void Configure(IServiceCollection svcCollection)
        {
            svcCollection.AddSingleton<IArticleRepository, ArticleRepository>();
        }
    }
}
