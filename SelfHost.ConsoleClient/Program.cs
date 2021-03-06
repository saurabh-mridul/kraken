﻿using Microsoft.AspNet.SignalR.Client;
using System;

namespace SelfHost.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting signalR...");
            RunSignalR();
            Console.ReadLine();
        }

        static void RunSignalR()
        {
            string url = "http://localhost:9000";
            HubConnection connection = new HubConnection(url);
            var proxy = connection.CreateHubProxy("chatHub");
            try
            {
                connection.Start().Wait();
                proxy.On<string>("displayTime", time =>
                 {
                     Console.WriteLine($"from server Time: {time}");
                 });
                proxy.Invoke("ServerTime");

                proxy.Invoke("Send", "Hello World", "mak", connection.ConnectionId).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        Console.WriteLine("There was an error opening the connection:{0}",
                                          task.Exception.GetBaseException());
                    }
                    else
                    {
                        Console.WriteLine("call completed.");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
