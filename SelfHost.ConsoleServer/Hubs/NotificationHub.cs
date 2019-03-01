using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SelfHost.ConsoleServer.Hubs
{
    [HubName("notificationHub")]
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

        public override Task OnConnected()
        {
            Console.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected(stopCalled));
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("Hub OnReconnected {0}\n", Context.ConnectionId);
            return (base.OnReconnected());
        }
    }
}
