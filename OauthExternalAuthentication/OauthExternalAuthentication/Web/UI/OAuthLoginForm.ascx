<%@ Control Language="C#" %>
<%@ Import Namespace="Microsoft.AspNet.Membership.OpenAuth" %>
<%@ Import Namespace="System.Linq" %>
<div id="oAuthProviders">
    <% if (OpenAuth.AuthenticationClients.GetAll().Any(p => p.ProviderName == "facebook"))
       { %>
    <a  href="javascript:void(0);" class="oauthloginprovider">
        <img id="facebook" src="<%=this.Page.ClientScript.GetWebResourceUrl(typeof(OauthExternalAuthentication.Web.UI.OAuthLoginForm), "OauthExternalAuthentication.Web.UI.Images.facebook.png")%>" alt="Facebook" />
    </a>
    <br />
    <%} %>
    <% if (OpenAuth.AuthenticationClients.GetAll().Any(p => p.ProviderName == "google"))
       { %>
    <a href="javascript:void(0);" class="oauthloginprovider">
        <img id="google" src="<%=this.Page.ClientScript.GetWebResourceUrl(typeof(OauthExternalAuthentication.Web.UI.OAuthLoginForm), "OauthExternalAuthentication.Web.UI.Images.google.png")%>" alt="Google" />
    </a>
    <br />
    <%} %>
    <% if (OpenAuth.AuthenticationClients.GetAll().Any(p => p.ProviderName == "amazon"))
       { %>
    <a href="javascript:void(0);" class="oauthloginprovider">
        <img id="amazon" src="<%=this.Page.ClientScript.GetWebResourceUrl(typeof(OauthExternalAuthentication.Web.UI.OAuthLoginForm), "OauthExternalAuthentication.Web.UI.Images.amazon.png")%>" alt="Amazon" />
    </a>
    <%} %>
    <% if (OpenAuth.AuthenticationClients.GetAll().Any(p => p.ProviderName == "twitter"))
       { %>
    <a href="javascript:void(0);" class="oauthloginprovider">
        <img id="twitter" src="<%=this.Page.ClientScript.GetWebResourceUrl(typeof(OauthExternalAuthentication.Web.UI.OAuthLoginForm), "OauthExternalAuthentication.Web.UI.Images.twitter.png")%>" alt="Twitter" />
    </a>
    <%} %>
</div>
