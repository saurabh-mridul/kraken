using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SelfHost.ConsoleServer.Controllers;
using SelfHost.ConsoleServer.Interfaces;
using SelfHost.ConsoleServer.Repositories;
using System.Net.Http.Formatting;
using System.Reflection;
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
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // ...or you can register individual controlllers manually.
            builder.RegisterType<TestController>().InstancePerRequest();

            //builder.Register(IOfferingRepository, c => new OfferingRepository());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            app.UseCors(CorsOptions.AllowAll);
            app.Map("/signalr", map =>
            {
                HubConfiguration hcf = new HubConfiguration { EnableJSONP = true, EnableDetailedErrors = true };
                map.RunSignalR(hcf);
            });

            // This adds ONLY the Autofac lifetime scope to the pipeline.
            app.UseAutofacLifetimeScopeInjector(container);

            // Now you can add middleware from the container into the pipeline
            // wherever you like. For example, this adds custom DI-enabled middleware
            // AFTER the Web API middleware/handling.
            app.UseWebApi(config);
        }
    }
}