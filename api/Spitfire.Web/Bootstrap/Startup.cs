using Microsoft.Owin;
using Spitfire.Web.Bootstrap;

[assembly: OwinStartup(typeof(Startup), "Configuration")]

namespace Spitfire.Web.Bootstrap
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            app.ConfigureAuth();
            app.ConfigureCors();
            app.ConfigureWebApi("/api");
        }
    }
}