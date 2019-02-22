using Microsoft.Owin.Hosting;
using System;

namespace SelfHost.ConsoleServer
{
    class Program
    {
        const string uri = "http://localhost:9000";
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine($"Server started at {uri} on {DateTime.UtcNow:F}");
                Console.ReadLine();
            }
        }
    }
}
