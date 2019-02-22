using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

namespace SelfHost.ConsoleServer
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseCors(CorsOptions.AllowAll);
            app.Map("/signalr", map =>
            {
                HubConfiguration hcf = new HubConfiguration { EnableJSONP = true };
                map.RunSignalR(hcf);
            });

            app.UseWebApi(config);
        }
    }
}