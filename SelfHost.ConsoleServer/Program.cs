using Microsoft.Owin.Hosting;
using System;

namespace SelfHost.ConsoleServer
{
    class Program
    {
        private static int port = 9000;
        static void Main(string[] args)
        {
            StartOptions options = new StartOptions();
            options.Urls.Add($"http://localhost:{port}");
            options.Urls.Add($"http://192.168.0.101:{port}");
            options.Urls.Add($"http://{Environment.MachineName}:{port}");

            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine($"Server started at port 9000 on {DateTime.UtcNow:F}");
                Console.ReadLine();
            }
        }
    }
}
