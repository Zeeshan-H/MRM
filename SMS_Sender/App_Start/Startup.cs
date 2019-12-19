using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using SMS_Sender.Provider;
using System.Web.Http;

[assembly: OwinStartup(typeof(SMS_Sender.App_Start.Startup))]

namespace SMS_Sender.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
               app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //The Path For generating the Toekn
                TokenEndpointPath = new PathString("/signin"),
                //Setting the Token Expired Time (24 hours)
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //MyAuthorizationServerProvider class will validate the user credentials
                Provider = new MyAuthorizationServerProvider()
            };
            //Token Generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
        
        }
    }
    

