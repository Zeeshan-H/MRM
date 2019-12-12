using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SMS_Sender.Models;
using SMS_Sender.Models.MemberViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SMS_Sender.Provider
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

       
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
          
                
            using (UserMasterRepository _repo = new UserMasterRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }

                //MemberModel model = new MemberModel();
                var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                    {
                    "Number", user.PrimaryNo
                    },
                    {
                   "Alternate Number", user.AltContactNo

                    },
                    {
                    "No Type", user.EmailAdd
                    },
                    {
                    "Email Add", user.EmailAdd
                    },
                    {
                    "Email Add2", user.EmailAdd2
                    }
                    });

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
                
                //identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
                //identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
           //     identity.AddClaim(new Claim("Email", user.PrimaryNo));

            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                //removed .issued and .expires parameter
                if (!property.Key.StartsWith("."))
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }


    }
}