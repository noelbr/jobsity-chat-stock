using System;
using System.Threading.Tasks;
using jobsity_chat.Services;
using Microsoft.AspNetCore.SignalR;

namespace jobsity_chat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string roomName, string usuario, string mensagem)
        {

            if (mensagem.Contains("/stock="))
            {
                StockService stockService = new StockService();
                string stock = mensagem.Substring(mensagem.IndexOf("/stock=")+7);
                stockService.GetQuote(roomName +","+stock);

                await Clients.Group(roomName).SendAsync("ReceiveMessage", usuario, "Request quote to "+ stock);
            }
            else
            {
                await Clients.Group(roomName).SendAsync("ReceiveMessage", usuario, mensagem);
                //await Clients.All.SendAsync("ReceiveMessage", usuario, mensagem);
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
