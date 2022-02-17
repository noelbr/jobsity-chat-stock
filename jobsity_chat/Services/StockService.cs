using System;
using System.Text;
using RabbitMQ.Client;

namespace jobsity_chat.Services
{
    public class StockService
    {
        private readonly ConnectionFactory _connectionFactory;

        public StockService(AppSettings appSettings)
        {

            _connectionFactory = new ConnectionFactory
            {
                HostName = appSettings.RabbitMqHostName,
                UserName = appSettings.RabbitMqUser,
                Password = appSettings.RabbitMqPassword
            };
        }
         
        public void GetQuote(string stock) {
             
            using (var connection = _connectionFactory.CreateConnection())
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
