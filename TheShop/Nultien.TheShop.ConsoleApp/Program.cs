using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nultien.TheShop.Common.DTO;
using Nultien.TheShop.Common.Exceptions.Validation;
using Nultien.TheShop.DataDomain;
using Nultien.TheShop.Impl.Repository;
using Nultien.TheShop.Interfaces.Repository;
using Nultien.TheShop.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nultien.TheShop.ConsoleApp
{
    public class Program
    {
        private static ILogger<Program> _logger;

        static void Main(string[] args)
        {
            var services = Startup.Configure();
            var serviceProvider = services.BuildServiceProvider();

            _logger = serviceProvider.GetService<ILogger<Program>>();
            _logger.LogInformation("TheShop is open!");

            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;

#if DEBUG
            DebugTest(serviceProvider);
#endif
        }

        private static void DebugTest(ServiceProvider svcProvider)
        {
            var articleSvc = svcProvider.GetService<IArticleService>();
            var supplierSvc = svcProvider.GetService<ISupplierService>();
            var stockRepo = svcProvider.GetService<ISupplierArticleRepository>();
            var shopService = svcProvider.GetService<IShopService>();

            var articleId = articleSvc.Add(new ArticleViewModel
            {
                ArticlePrice = 100,
                Name_of_article = "Test Article"
            });

            var supplierIds = new List<int>();

            supplierIds.Add(supplierSvc.Add(new SupplierViewModel
            {
                Name = "Supplire 1"
            }));

            supplierIds.Add(supplierSvc.Add(new SupplierViewModel
            {
                Name = "Supplire 2"
            }));

            supplierIds.Add(supplierSvc.Add(new SupplierViewModel
            {
                Name = "Supplire 3"
            }));

            Random rnd = new Random();

            supplierIds.ForEach(supplierId =>
            {
                stockRepo.Upsert(new SupplierStock
                {
                    ArticleID = articleId, 
                    SupplierID = supplierId,
                    Price = rnd.Next(10, 1000),
                    Quantity = rnd.Next(1, 11)
                });
            });

            shopService.OrderAndSellArticle(articleId, 1000, 1);

        }

        /// <summary>
        /// Handles unhandled exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            _logger.LogError(e.ExceptionObject as Exception, "Unexpected error occured.");
            Environment.Exit(-1);
        }
    }
}
