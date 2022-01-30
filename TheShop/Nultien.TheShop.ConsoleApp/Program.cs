using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nultien.TheShop.Interfaces.Services;
using System;

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

            System.AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;


            var shopService = serviceProvider.GetService<IShopService>();

            var article = shopService.GetById(1);
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
