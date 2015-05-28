namespace Spitfire.Web.Bootstrap
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using Microsoft.Owin.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Owin;
    using StructureMap;
    using StructureMap.Infrastructure;
    using WebApiProblem;

    internal static class WebApi
    {
        internal static void ConfigureWebApi(this IAppBuilder app, string basePath)
        {
            var config = new HttpConfiguration();

            // Enable Attribute based routing
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator(new DefaultContainer()));

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Filters.Add(new ResponseExceptionFilterAttribute());
            config.Filters.Add(new WebApiProblemFilterAttribute());

            // Configure JSON.NET to properly camelCase replies and to not fail on reference loops
            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            app.Map(basePath, inner =>
            {
                // Configure Web API
                inner.UseWebApi(config);

                // Needed to fix some IIS issues
                inner.UseStageMarker(PipelineStage.MapHandler);
            });
        }
    }
}