
using System.Web;
using IdentityServer3.Core.Services;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;

//using IdentityServer3.Host.Config;


using Microsoft.IdentityModel.Protocols;
//using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
//using Microsoft.Owin.Security.OpenIdConnect;
//using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Web.Helpers;
using IdentityServer3.Core;
//using IdentityServer3.Core.Configuration;
using IdentityModel.Client;
using System.Threading.Tasks;
using IdentityServer3.Core.Services.InMemory;
using IdentityServer3.Core.Models;
//using IdentityServer3.Core.Services;
using IdentityServer3.AccessTokenValidation;
using System.Web.Http;
using IdentityServer3.Core.Logging;
using IdentityServer3.EntityFramework;
using IdentityServer3.Core.Services.Default;
using ServerMVC;
using ServerMVC.Samples.IdSvrServices;
using ServerMVC.Controllers;

[assembly: OwinStartup(typeof(ServerMVC.Startup))]

namespace ServerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            var factory = new IdentityServerServiceFactory()
                   .UseInMemoryUsers(Confg.ConsegUsers.Get())
                   .UseInMemoryClients(Confg.ConsegClients.Get())
                   .UseInMemoryScopes(Confg.ConsegScopes.Get());

            // Use the Mvc View Service instead of the default
            factory.ViewService = new Registration<IViewService, MvcViewService<LogonWorkflowController>>();

            // These registrations are also needed since these are dealt with using non-standard construction
            factory.Register(new Registration<HttpContext>(resolver => HttpContext.Current));
            factory.Register(new Registration<HttpContextBase>(resolver => new HttpContextWrapper(resolver.Resolve<HttpContext>())));
            factory.Register(new Registration<HttpRequestBase>(resolver => resolver.Resolve<HttpContextBase>().Request));
            factory.Register(new Registration<HttpResponseBase>(resolver => resolver.Resolve<HttpContextBase>().Response));
            factory.Register(new Registration<HttpServerUtilityBase>(resolver => resolver.Resolve<HttpContextBase>().Server));
            factory.Register(new Registration<HttpSessionStateBase>(resolver => resolver.Resolve<HttpContextBase>().Session));

            //var Scripts = new DefaultViewServiceOptions();
            //Scripts.Scripts.Add("/Services/Content/app/api.js");
            //factory.ConfigureDefaultViewService(Scripts);
            //factory.ViewService = new Registration<IViewService, Services.CustomViewService>();
            //factory.UserService = new Registration<IUserService, Services.UserService>();

            var options = new IdentityServerOptions
            {
                //EnableWelcomePage = false,
                SiteName = "Servidor de Autenticação SSP",
                SigningCertificate = Confg.CertificateLoad.Get(), /*new X509Certificate2(Certificate, ConfigurationManager.AppSettings["SigningCertificatePassword"]),*/
                RequireSsl = false,
                Factory = factory,
                AuthenticationOptions = new IdentityServer3.Core.Configuration.AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect = true,
                    IdentityProviders = ConfigureIdentityProviders
                }
            };
            app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = "Cookies" });
            app.UseIdentityServer(options);

            //app.Map("/core", idsrvApp =>
            //{
            //    idsrvApp.UseIdentityServer(options);
            //});

            ConfigureAuth(app);
        }

        private void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                Caption = "Sign-in with Google",
                SignInAsAuthenticationType = signInAsType,

                ClientId = "701386055558-9epl93fgsjfmdn14frqvaq2r9i44qgaa.apps.googleusercontent.com",
                ClientSecret = "3pyawKDWaXwsPuRDL7LtKm_o"
            });
        }
        private static void ConfigureClients(IEnumerable<Client> clients, EntityFrameworkServiceOptions options)
        {
            using (var db = new ClientConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                if (!db.Clients.Any())
                {
                    foreach (var c in clients)
                    {
                        var e = c.ToEntity();
                        db.Clients.Add(e);
                    }
                    db.SaveChanges();
                }
            }
        }
        private static void ConfigureScopes(IEnumerable<Scope> clients, EntityFrameworkServiceOptions options)
        {
            using (var db = new ScopeConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                if (!db.Scopes.Any())
                {
                    foreach (var c in clients)
                    {
                        var e = c.ToEntity();
                        db.Scopes.Add(e);
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
