using System;
namespace jobsity_stockWorker.Services.Chat.Requests
{
    public class StockRequest
    {
        public string RoomName { get; set; }
        public string Name { get; set; }
        public float Quote { get; set; }
    }
}
