using DotNetOpenAuth.AspNet;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Linq;
using System.Text;
using System.Web;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Security.Model;
using Telerik.Sitefinity.Services;

namespace OauthExternalAuthentication
{
    public class OAuthAuthenticationHttpHandler : SecurityTokenServiceHttpHandler
    {
        public override void ProcessRequest(System.Web.HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request.QueryString["state"]))
            {
                this.TranslateStateArgument(context);
            }

            if (!String.IsNullOrWhiteSpace(context.Request.QueryString["redirectOauth"]) && context.Request.QueryString["redirectOauth"] == "true")
            {
                var authResult = OpenAuth.VerifyAuthentication(HttpContext.Current.Request.RawUrl);

                if (authResult.IsSuccessful)
                {
                    this.HandleSuccessfullOAuth(authResult, context);
                }
                else
                {
                    this.HandleFailureOAuth(authResult, context);
                }
            }

            base.ProcessRequest(context);
        }

        private void TranslateStateArgument(HttpContext context)
        {
            var stateQueryString = context.Request.QueryString["state"];
            var decodedQueryString = stateQueryString;

            if (stateQueryString == null || !stateQueryString.Contains("__provider__=google"))
            {
                decodedQueryString = System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(stateQueryString));
                if (decodedQueryString.StartsWith("?"))
                    decodedQueryString = decodedQueryString.Substring(1);
            }

            UriBuilder builder = new UriBuilder(context.Request.Url.GetLeftPart(UriPartial.Path));
            var queryStringBuilder = new StringBuilder();
            var otherKeys = context.Request.QueryString.AllKeys.Where(p => p != "state");

            queryStringBuilder.Append(decodedQueryString);

            foreach (var key in otherKeys)
            {
                if (!queryStringBuilder.ToString().Contains(key + "="))
                {
                    queryStringBuilder.Append("&");
                    queryStringBuilder.Append(key);
                    queryStringBuilder.Append("=");
                    queryStringBuilder.Append(context.Request.QueryString[key]);
                }
            }

            builder.Query = queryStringBuilder.ToString();
            context.Response.Redirect(builder.Uri.AbsoluteUri);
        }

        private void HandleSuccessfullOAuth(AuthenticationResult authResult, System.Web.HttpContext context)
        {
            string externalProviderName = authResult.Provider;
            string externalUserId = authResult.ProviderUserId;
            string externalUserName = authResult.UserName;

            string userName = string.Concat(externalUserName.Replace(" ", ""), "_", externalUserId, "_", externalProviderName);

            var userManager = UserManager.GetManager();
            var currentUser = userManager.GetUsers().Where(user => user.UserName == userName).FirstOrDefault();
            if (currentUser == null)
            {
                string name = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;
                string email = string.Empty;
                if (authResult.ExtraData.ContainsKey("name"))
                {
                    name = authResult.ExtraData["name"];
                }

                if (authResult.ExtraData.ContainsKey("given_name"))
                {
                    firstName = authResult.ExtraData["given_name"];
                }

                if (authResult.ExtraData.ContainsKey("family_name"))
                {
                    lastName = authResult.ExtraData["family_name"];
                }

                if (authResult.ExtraData.ContainsKey("email"))
                {
                    email = authResult.ExtraData["email"];
                }

                // facebook gives user email as username
                if (authResult.ExtraData.ContainsKey("username") && authResult.ExtraData["username"].Contains("@"))
                {
                    email = authResult.ExtraData["username"];
                }

                // try to extract first and last name from name
                if (!name.IsNullOrEmpty() && name.Contains(" ") && firstName.IsNullOrEmpty() && lastName.IsNullOrEmpty())
                {
                    string[] nameParts = name.Split(new char[] { ' ' }, 2);
                    firstName = nameParts[0];
                    lastName = nameParts[1];
                }

                // as a last resort, use the username from the external provider as first name
                if (firstName.IsNullOrEmpty() && lastName.IsNullOrEmpty())
                {
                    firstName = externalUserName;
                }

                SystemManager.RunWithElevatedPrivilege(p => { this.CreateUser(userName, firstName, lastName, externalUserName, email); });

                currentUser = userManager.GetUsers().Where(user => user.UserName == userName).FirstOrDefault();
            }

            var vals = context.Request.RequestContext.RouteData.Values;
            var service = ((string)vals["Service"]).ToLower();

            this.SetAuthCookie(currentUser);
            var reqMessage = RequestMessage.Empty;
            this.SendToken(context, currentUser, reqMessage, service);
        }

        private void HandleFailureOAuth(AuthenticationResult authResult, HttpContext context)
        {
            if (!string.IsNullOrWhiteSpace(context.Request.QueryString["redirect_url_failure"]))
            {
                context.Response.Redirect(context.Request.QueryString["redirect_url_failure"]);

                context.ApplicationInstance.CompleteRequest();
                return;
            }
        }

        private void CreateUser(string username, string firstname, string lastname, string nickname, string email)
        {
            var userManager = UserManager.GetManager();
            var profileManager = UserProfileManager.GetManager();

            var currentUser = userManager.CreateUser(username);
            currentUser.IsBackendUser = false;
            currentUser.Email = email;

            userManager.SaveChanges();

            var profile = profileManager.CreateProfile(currentUser, "Telerik.Sitefinity.Security.Model.SitefinityProfile") as SitefinityProfile;
            profile.FirstName = firstname;
            profile.LastName = lastname;
            profile.Nickname = nickname;
            profileManager.RecompileItemUrls<SitefinityProfile>(profile);

            profileManager.SaveChanges();
        }

        protected override void SendLoginForm(HttpContext context, string message)
        {
            this.SentLoginForm();
            base.SendLoginForm(context, message);
        }

        protected override void SendLoginForm(HttpContextBase context, string message)
        {
            this.SentLoginForm();
            base.SendLoginForm(context, message);
        }

        private void SentLoginForm()
        {
            if (!String.IsNullOrWhiteSpace(SystemManager.CurrentHttpContext.Request.QueryString["oaprovider"]))
            {
                OpenAuth.RequestAuthentication(SystemManager.CurrentHttpContext.Request.QueryString["oaprovider"],
                    SystemManager.CurrentHttpContext.Request.RawUrl + "&redirectOauth=true"
                    );
            }
        }
    }
}
