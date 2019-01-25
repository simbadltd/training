using System;
using System.IO;
using System.Web.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using TestTion.App.Persistence;

namespace TestTion.App
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // configure all of the services required for DI
            ConfigureServices();

            // Configure Web API for self-host.
            HttpConfiguration config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

            var rootFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientApp\\dist");
            var fileSystem = new PhysicalFileSystem(rootFolder);
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = fileSystem
            };

            appBuilder.UseFileServer(options);
        }

        private static void ConfigureServices()
        {
            TinyIoC.TinyIoCContainer.Current.Register<IDbContextFactory, DbContextFactory>().AsSingleton();
            TinyIoC.TinyIoCContainer.Current.Register<IPetRepository, PetRepository>().AsMultiInstance();
        }
    }
}