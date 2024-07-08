using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace E_Chat.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("Welcome", "Hello Erfan");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string text)
        {
            var userName = Context.User.FindFirstValue(ClaimTypes.Name);
            await Clients.Others.SendAsync("ReceiveMessage", $"{userName}: {text}");
        }
    }
}