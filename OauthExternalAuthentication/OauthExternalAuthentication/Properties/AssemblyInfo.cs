using OauthExternalAuthentication;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("OauthExternalAuthentication")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("OauthExternalAuthentication")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f6e6dc3a-1ae3-4c27-98cb-1a0588a2d8e9")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: System.Web.UI.WebResource("OauthExternalAuthentication.Web.UI.Images.facebook.png", "img/png")]
[assembly: System.Web.UI.WebResource("OauthExternalAuthentication.Web.UI.Images.google.png", "img/png")]
[assembly: System.Web.UI.WebResource("OauthExternalAuthentication.Web.UI.Images.amazon.png", "img/png")]
[assembly: System.Web.UI.WebResource("OauthExternalAuthentication.Web.UI.Images.twitter.png", "img/png")]
[assembly: System.Web.UI.WebResource("OauthExternalAuthentication.Web.UI.Styles.Login.css", "text/css")]


[assembly: PreApplicationStartMethod(typeof(Installer), "PreApplicationStart")]




[assembly: Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes.ControllerContainer]

[assembly: Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes.ResourcePackage]
