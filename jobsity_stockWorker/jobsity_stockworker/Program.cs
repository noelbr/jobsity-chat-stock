using System;
using System.IO;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Stock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace jobsity_stockWorker
{
    class Program
    {
        public static IConfigurationRoot configuration;


        static void Main(string[] args)
        { 
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args) 
           .ConfigureServices((hostContext, services) =>
           {
               ConfigureServices(services);
               services.AddHostedService<StockWorker>();
           });

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {


            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);


            AppSettings appSettings = configuration.Get<AppSettings>();
            serviceCollection.AddSingleton(instance => appSettings);

        }
    }


}

