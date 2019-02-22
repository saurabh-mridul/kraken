using Microsoft.AspNet.SignalR;
using System;
using System.Threading;

namespace SelfHost.ConsoleServer.Hubs
{
    public class NotificationHub : Hub
    {
        public void ServerTime()
        {
            do
            {
                Console.WriteLine($"Client Id: {Context.ConnectionId} Time called:{DateTime.UtcNow}");
                Clients.All.displayTime($"{DateTime.UtcNow:T}");
                Thread.Sleep(TimeSpan.FromSeconds(1));

            } while (true);
        }
    }
}
