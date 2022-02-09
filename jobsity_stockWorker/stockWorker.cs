using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using jobsity_stockWorker.Services.Chat;
using jobsity_stockWorker.Services.Chat.Requests;
using jobsity_stockWorker.Services.Stock;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace jobsity_stockWorker
{
    public class stockWorker :  BackgroundService
    {
   

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
             
            var factory = new ConnectionFactory()
            {
                HostName = "rabbitmq3",
                UserName = "myuser",
                Password = "mypassword",
                //Port = 5672
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "stock",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(queue: "stock",
                autoAck: true,
                consumer: consumer);


            while (!stoppingToken.IsCancellationRequested)
            {
                
                await Task.Delay(5000, stoppingToken);
            }
        }

        private void Consumer_Received(
            object sender, BasicDeliverEventArgs e)
        {

            var payload = Encoding.UTF8.GetString(e.Body.ToArray()).Split(",");
            string chatRoom =  payload[0];
            string stock = payload[1];


            Console.WriteLine("Revice resuest stock =>" + stock );

            StockClient stockClient = new StockClient();
            ChatClient chatClient = new ChatClient();

            var simbolsResult = stockClient.Get(stock).Result;
            bool existStock = false;
            foreach (var item in simbolsResult.Symbols)
            {
                Console.WriteLine("stock =>" + item.Symbol );
                Console.WriteLine("Quote =>" + item.Close );

                if (item.Close != 0) {
                    existStock = true;
                    chatClient.SendStock(new StockRequest
                    {
                        RoomName = chatRoom,
                        Name = item.Symbol,
                        Quote = item.Close
                    }).Wait(); 

                    Console.WriteLine("chat message sended");
                } 
            }

            if (!existStock) {
                
                Console.WriteLine("no quote avaliable");

                chatClient.SendStock(new StockRequest
                {
                    Name = stock,
                    Quote = 0
                }).Wait();

                Console.WriteLine("chat message sended");
            }


        }
    }
}
