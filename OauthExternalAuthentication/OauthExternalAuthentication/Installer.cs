using System;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Services;

namespace OauthExternalAuthentication
{
    public class Installer
    {
        /// <summary>
        /// This is the actual method that is called by ASP.NET even before application start. Sweet!
        /// </summary>
        public static void PreApplicationStart()
        {
            // With this method we subscribe for the Sitefinity Bootstrapper_Initialized event, which is fired after initialization of the Sitefinity application
            Bootstrapper.Initialized += (new EventHandler<ExecutedEventArgs>(Installer.Bootstrapper_Initialized));
        }

        /// <summary>
        /// With this method we subscribe for the Sitefinity Bootstrapper_Initiali
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName != "RegisterRoutes" || !Bootstrapper.IsDataInitialized)
            {
                return;
            }

            InstallModule();
        }


        /// <summary>
        /// Below you will see how modules can be programmatically installed
        /// </summary>
        private static void InstallModule()
        {
            // define content view control
            var modulesConfig = Config.Get<SystemConfig>().ApplicationModules;
            var module = new OAuthAuthenticationModule();
            AppModuleSettings customFieldsSetting = modulesConfig.Elements.Where(el => el.GetKey().Equals(module.Name)).SingleOrDefault();
            if (customFieldsSetting == null)
            {
                AppModuleSettings moduleConfigElement = new AppModuleSettings(modulesConfig)
                {
                    Name = module.Name,
                    Title = module.Title,
                    Description = module.Description,
                    Type = typeof(OAuthAuthenticationModule).AssemblyQualifiedName,
                    StartupType = StartupType.OnApplicationStart
                };

                // Registerign the module
                modulesConfig.Add(module.Name, moduleConfigElement);

                ConfigManager.GetManager().SaveSection(modulesConfig.Section);
                SystemManager.RestartApplication(false);
            }
        }
    }
}
