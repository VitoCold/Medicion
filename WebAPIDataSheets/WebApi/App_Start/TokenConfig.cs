using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Auth;
using WebApi.Repositories.Interfaces;
using WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.App_Start
{
    public class TokenConfig
    {
        public static void ConfigureOAuth(IAppBuilder app, HttpConfiguration config)
        {
            var unitOfWork = (IUnitOfWork)config.DependencyResolver.GetService(typeof(IUnitOfWork));
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }

    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //private readonly IUnitOfWork _unit;
        //private readonly Users _auth;
        //private readonly ApplicationSignInManager _signInManager;
        //private readonly ApplicationUserManager _userManager;

        public SimpleAuthorizationServerProvider()
        {
            //_auth = new Users(_userManager,_signInManager);
            //_auth = new Users();
        }

        public override async Task ValidateClientAuthentication(
            OAuthValidateClientAuthenticationContext context)
        {
            await Task.Factory.StartNew(() => { context.Validated(); });
        }

        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Factory.StartNew( () =>{

                var appUserManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

                IdentityUser user = appUserManager.FindAsync(context.UserName, context.Password).Result;

                if (user==null)
                {
                    context.SetError("invalid_grant", "Usuario o clave incorrecta");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            });
        }

       
    }
}