using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HitCounter.Hubs
{
    [HubName("HitCounter")]
    public class HitCounterHub : Hub
    {
        private static int count;
        private static object syncLock = new object();

        public override Task OnConnected()
        {
            lock (syncLock)
                count++;

            Clients.Caller.Status(count);

            return base.OnConnected();
        }
    }
}