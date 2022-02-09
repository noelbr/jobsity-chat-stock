using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using jobsity_chat.Hubs;
using jobsity_chat.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jobsity_chat.Controllers
{
   


    [Route("api/[controller]")]
    public class StockController : Controller
    {

        public static IHubContext<ChatHub> HubContext; 
        public StockController(IHubContext<ChatHub> hubContext)
        {
            HubContext = hubContext;
           
        }
         

        // POST api/values
        [HttpPost]
        public void Post([FromBody] StockRequest request)
        {
            if (request.Quote == 0)
            {
                HubContext.Clients.Group(request.RoomName).SendAsync("ReceiveMessage", "Bot", request.Name.ToUpper() + " quote not found");

            } 
            else
            { 
                HubContext.Clients.Group(request.RoomName).SendAsync("ReceiveMessage", "Bot", request.Name.ToUpper() + " quote is $" + request.Quote + " per share");
            }  
        }
 
    }
}
