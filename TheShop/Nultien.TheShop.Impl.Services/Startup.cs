using Microsoft.Extensions.DependencyInjection;
using Nultien.TheShop.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Impl.Services
{
    public class Startup
    {
        public static void Configure(IServiceCollection svcCollection)
        {
            svcCollection.AddAutoMapper(typeof(Startup));
            svcCollection.AddSingleton<IArticleService, ArticleService>();
        }
    }
}
