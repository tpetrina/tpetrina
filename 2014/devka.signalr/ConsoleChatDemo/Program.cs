using System;
using Microsoft.AspNet.SignalR.Client;

namespace ConsoleChatDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:11628/");
            var moveShape = hubConnection.CreateHubProxy("Shapes");
            moveShape.On<int, int>("shapeMoved", (x, y) => Console.WriteLine("shape moved to {0}, {1}", x, y));

            hubConnection.Start().Wait();

            Console.WriteLine("connected");
            Console.ReadKey();
        }
    }
}
