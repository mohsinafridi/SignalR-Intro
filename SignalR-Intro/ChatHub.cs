using Microsoft.AspNetCore.SignalR;
using SignalR_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Intro
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Explore California", DateTimeOffset.UtcNow, "Hello! What can we help you with today?");

            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string name,string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.UtcNow
            };

            // Broadcast to All Clients
            await Clients.All.SendAsync("ReceiveMessage", message.SenderName, message.SendAt, message.Text);


        }
    }
}
