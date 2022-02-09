using System;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Stock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace jobsity_stockWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            while(true)
            {
                try
                {
                    var factory = new ConnectionFactory()
                    {
                        HostName = "rabbitmq3",
                        UserName = "myuser",
                        Password = "mypassword",
                        //Port = 5672
                    };
                    using var connection = factory.CreateConnection();
                    Console.WriteLine("RabbitMQ avaliable");
                    break;
                }
                catch (Exception ex)
                { 
                    Console.WriteLine("RabbitMQ offline");
                    Console.WriteLine(ex.Message);
                    Task.Delay(15000).Wait();
                }
              
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {

               services.AddHostedService<stockWorker>();
           });
        
    }
}

