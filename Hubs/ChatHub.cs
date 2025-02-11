using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    private static List<(string User, string Message)> messages = new();

    public async Task SendMessage(string user, string message)
    {
        if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(message))
            return;

        user = System.Net.WebUtility.HtmlEncode(user); 
        message = System.Net.WebUtility.HtmlEncode(message);

        messages.Add((user, message));
        if (messages.Count > 50) messages.RemoveAt(0);

        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task LoadMessages()
    {
        foreach (var msg in messages)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", msg.User, msg.Message);
        }
    }
}
