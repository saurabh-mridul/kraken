﻿using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace SelfHost.ConsoleServer.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : NotificationHub
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
    }
}
