using System;
using System.Threading.Tasks;
using jobsity_chat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace jobsity_chat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {

        public AppSettings _appSettings;
             
        public ChatHub(AppSettings appSettings )
        {
            _appSettings = appSettings;
        }


        public async Task SendMessage(string roomName, string mensagem)
        {
             

            if (mensagem.Contains("/stock="))
            {
                StockService stockService = new StockService(_appSettings);
                string stock = mensagem.Substring(mensagem.IndexOf("/stock=")+7);
                stockService.GetQuote(roomName +","+stock);

                await Clients.Group(roomName).SendAsync("ReceiveMessage", Context.User.Identity.Name, "Request quote to "+ stock);
            }
            else
            {
                await Clients.Group(roomName).SendAsync("ReceiveMessage", Context.User.Identity.Name, mensagem); 
            }
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
