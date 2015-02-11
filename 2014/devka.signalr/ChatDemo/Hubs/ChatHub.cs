using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatDemo.Hubs
{
    [HubName("Chat")]
    public class ChatHub : Hub
    {
        public void Message(string message)
        {
            Clients.All.Receive(message);
        }
    }
}
