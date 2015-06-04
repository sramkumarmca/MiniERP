namespace Spitfire.Web.Bootstrap
{
    using System.IdentityModel.Tokens;
    using Microsoft.Owin.Cors;
    using Microsoft.Owin.Security.ActiveDirectory;
    using Owin;
    using Properties;

    public static class Auth
    {
        internal static void ConfigureCors(this IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
        }

        internal static void ConfigureAuth(this IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = Settings.Default.Audience
                    },
                    Tenant = Settings.Default.Tenant
                });
        }
    }
}