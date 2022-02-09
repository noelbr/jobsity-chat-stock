using System;
using System.Text;
using RabbitMQ.Client;

namespace jobsity_chat.Services
{
    public class StockService
    {
        public void GetQuote(string stock) {

            var connectionFactory = new ConnectionFactory
            {
                HostName = "rabbitmq3",
                UserName = "myuser",
                Password = "mypassword",
                //Port = 5672
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    channel.QueueDeclare("stock", false, false, false, null);

                    var strigfiedMessage = stock;

                    var bytesMessage = Encoding.UTF8.GetBytes(strigfiedMessage);

                    channel.BasicPublish(exchange: "", routingKey: "stock", basicProperties: null, body: bytesMessage);
                }


            }

        }
    }
}
