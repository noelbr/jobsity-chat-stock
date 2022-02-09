using System;
namespace jobsity_chat.Requests
{
    public class StockRequest
    { 
        public string RoomName { get; set; }
        public string Name { get; set; }
        public float Quote { get; set; }
    }
}
