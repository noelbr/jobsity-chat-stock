using System;
namespace jobsity_stockWorker
{
    public class AppSettings
    {
        public string RabbitMqHostName { get; set; }
        public string RabbitMqUser { get; set; }
        public string RabbitMqPassword { get; set; }
        public string StockAPI { get; set; }
        public string ChatAPI { get; set; }
    }
}
