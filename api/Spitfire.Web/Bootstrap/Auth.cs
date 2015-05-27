namespace Spitfire.Web.Bootstrap
{
    using System;
    using System.Security.Claims;
    using GNaP.Owin.Authentication.Jwt;
    using Microsoft.Owin.Cors;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Jwt;
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
            var issuer = Settings.Default.Issuer;
            var audience = Settings.Default.Audience;
            var tokenSigningKey = Settings.Default.TokenSigningKey;

            app.UseJwtTokenIssuer(
                new JwtTokenIssuerOptions
                {
                    Issuer = issuer,
                    Audience = audience,
                    TokenSigningKey = tokenSigningKey,
                    Authenticate = (username, password) =>
                    {
                        // TODO: Implement your own authentication check here
                        if (username.Equals("gnap"))
                        {
                            return new[]
                            {
                                // TODO: Implement your own claims here
                                new Claim(ClaimTypes.AuthenticationInstant, DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")),
                                new Claim(ClaimTypes.AuthenticationMethod, AuthenticationTypes.Password),
                                new Claim(ClaimTypes.Name, username)
                            };
                        }

                        // Invalid user
                        return null;
                    }
                });

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                                                   {
                                                       new SymmetricKeyIssuerSecurityTokenProvider(issuer, tokenSigningKey)
                                                   }
                });
        }
    }
}