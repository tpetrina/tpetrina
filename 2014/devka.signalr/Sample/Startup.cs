using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Sample.Startup), "Configuration")]
namespace Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Microsoft.AspNet.SignalR.StockTicker.Startup.ConfigureSignalR(app);
        }
    }
}