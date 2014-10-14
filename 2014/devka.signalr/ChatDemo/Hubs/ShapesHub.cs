using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatDemo.Hubs
{
    [HubName("Shapes")]
    public class ShapesHub : Hub
    {
        public void MoveShape(int x, int y)
        {
            Clients.Others.ShapeMoved(x, y);
        }
    }
}
