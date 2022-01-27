using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nultien.TheShop.Interfaces.Services;
using System;

namespace Nultien.TheShop.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = Startup.Configure();
            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogInformation("Application start");


            var articleServices = serviceProvider.GetService<IArticleService>();

            var article = articleServices.GetById(1);

            Console.WriteLine(article.Name_of_article);
        }
    }
}
