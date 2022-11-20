
using Microsoft.AspNetCore.SignalR;

namespace SignalR_POC
{
    public class MessageHub : Hub
    {
        public Task SendMessage1(string user, string message)               // Two parameters accepted
        {
            return Clients.All.SendAsync("ReceiveOne", user, message);    // Note this 'ReceiveOne' 
        }
    }
}
