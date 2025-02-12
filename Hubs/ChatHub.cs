using Microsoft.AspNetCore.SignalR;

namespace simple_chat_csharp;

public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
