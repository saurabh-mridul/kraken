using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading.Tasks;

namespace SelfHost.ConsoleServer.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public void Send(string message, string userName, string connectionId)
        {
            Clients.Caller.addMessage(userName, message);
            Clients.Client(connectionId).addMessage(userName, message);
            Console.WriteLine($"recieved message: {message} from {userName}");
        }

        public void SendToGroup(string message, string userName, string groupName)
        {
            Clients.Group(groupName).addMessage(message, userName);
        }

        public void BroadCast(string message, string userName)
        {
            Clients.All.addMessage(message, userName);
        }

        public void JoinGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
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
