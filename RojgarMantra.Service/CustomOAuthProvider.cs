//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.OAuth;
//using RojgarMantra.Data.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;

//namespace RojgarMantra.Service
//{
//    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
//    {

//        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
//        {
///*            string clientId = string.Empty;
//            string clientSecret = string.Empty;
//            string symmetricKeyAsBase64 = string.Empty;

//            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
//            {
//                context.TryGetFormCredentials(out clientId, out clientSecret);
//            }

//            if (context.ClientId == null)
//            {
//                context.SetError("invalid_clientId", "client_Id is not set");
//                return Task.FromResult<object>(null);
//            }

//            var audience = AudiencesStore.FindAudience(context.ClientId);

//            if (audience == null)
//            {
//                context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
//                return Task.FromResult<object>(null);
//            }*/

//            context.Validated();
//            return Task.FromResult<object>(null);
//        }

//        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
//        {

//            var allowedOrigin = "*";

//            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

//            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

//            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

//            if (user == null)
//            {
//                context.SetError("invalid_grant", "The user name or password is incorrect.");
//                return;
//            }

//            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

//            var ticket = new AuthenticationTicket(oAuthIdentity, null);

//            context.Validated(ticket);
//        }
//    }
//}
