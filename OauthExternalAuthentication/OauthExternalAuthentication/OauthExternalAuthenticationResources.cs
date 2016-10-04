using Telerik.Sitefinity.Localization;

namespace OauthExternalAuthentication
{
    [ObjectInfo(typeof(OauthExternalAuthenticationResources), Title = "OAEResourcesTitle", Description = "OAEDescription")]
    public class OauthExternalAuthenticationResources : Resource 
    {
        #region Class Description

        /// <summary>
        /// Help
        /// </summary>
        /// <value>
        /// The oae resources title.
        /// </value>
        [ResourceEntry("OAEResourcesTitle",
                       Value = "Open Authentican Module Resources",
                       Description = "The title of this class.",
                       LastModified = "2013/06/01")]
        public string OAEResourcesTitle
        {
            get
            {
                return this["OAEResourcesTitle"];
            }
        }

        /// <summary>
        /// Contains localizable resources for help information such as UI elements descriptions, usage explanations, FAQ and etc.
        /// </summary>
        [ResourceEntry("OAEDescription",
                       Value = "Contains localizable resources for security user interface.",
                       Description = "The description of this class.",
                       LastModified = "2013/06/01")]
        public string OAEDescription
        {
            get
            {
                return this["OAEDescription"];
            }
        }

        #endregion

        #region Config Descriptions

        #region Facebook 
       
        [ResourceEntry("FacebookAPPIDTitle",
                       Value = "Facebook Application ID",
                       Description = "Facebook Application ID Title",
                       LastModified = "2013/06/01")]
        public string FacebookAPPIDTitle
        {
            get
            {
                return this["FacebookAPPIDTitle"];
            }
        }

        [ResourceEntry("FacebookAPPIDDescription",
                      Value = "Facebook Application ID",
                      Description = "Facebook Application ID Description",
                      LastModified = "2013/06/01")]
        public string FacebookAPPIDDescription
        {
            get
            {
                return this["FacebookAPPIDDescription"];
            }
        }        

        [ResourceEntry("FacebookAPPSecretKeyTitle",
                    Value = "Facebook Application Secret Key",
                    Description = "Facebook Application Secret Key Title",
                    LastModified = "2013/06/01")]
        public string FacebookAPPSecretKeyTitle
        {
            get
            {
                return this["FacebookAPPSecretKeyTitle"];
            }
        }

        [ResourceEntry("FacebookAPPSecretKeyDescription",
                      Value = "Facebook Application Secret Key",
                      Description = "Facebook Application Secret Key Description",
                      LastModified = "2013/06/01")]
        public string FacebookAPPSecretKeyDescription
        {
            get
            {
                return this["FacebookAPPSecretKeyDescription"];
            }
        }

        #endregion

        #region GooglePlus

        [ResourceEntry("GoogleClientIDTitle",
                      Value = "Google Client ID",
                      Description = "Google Client ID Title",
                      LastModified = "2016/07/27")]
        public string GoogleClientIDTitle
        {
            get
            {
                return this["GoogleClientIDTitle"];
            }
        }

        [ResourceEntry("GoogleClientIDDescription",
                   Value = "Google Client ID",
                   Description = "Google Client ID Description",
                   LastModified = "2016/07/27")]
        public string GoogleClientIDDescription
        {
            get
            {
                return this["GoogleClientIDDescription"];
            }
        }

        [ResourceEntry("GoogleClientSecretTitle",
                   Value = "Google Client Secret",
                   Description = "Google Client Secret Title",
                   LastModified = "2016/07/27")]
        public string GoogleClientSecretTitle
        {
            get
            {
                return this["GoogleClientSecretTitle"];
            }
        }

        [ResourceEntry("GoogleClientSecretDescription",
                Value = "Google Client Secret",
                Description = "Google Client Secret Description",
                LastModified = "2016/07/27")]
        public string GoogleClientSecretDescription
        {
            get
            {
                return this["GoogleClientSecretDescription"];
            }
        }

        #endregion

        #region Amazon

        [ResourceEntry("AmazonAPPIDTitle",
                       Value = "Amazon Application ID",
                       Description = "Amazon Application ID Title",
                       LastModified = "2013/06/01")]
        public string AmazonAPPIDTitle
        {
            get
            {
                return this["AmazonAPPIDTitle"];
            }
        }

        [ResourceEntry("AmazonAPPIDDescription",
                      Value = "Amazon Application ID",
                      Description = "Amazon Application ID Description",
                      LastModified = "2013/06/01")]
        public string AmazonAPPIDDescription
        {
            get
            {
                return this["AmazonAPPIDDescription"];
            }
        }        

        [ResourceEntry("AmazonAPPSecretKeyTitle",
                    Value = "Amazon Application Secret Key",
                    Description = "Amazon Application Secret Key",
                    LastModified = "2013/06/01")]
        public string AmazonAPPSecretKeyTitle
        {
            get
            {
                return this["AmazonAPPSecretKeyTitle"];
            }
        }

        [ResourceEntry("AmazonAPPSecretKeyDescription",
                      Value = "Amazon Application Secret Key",
                      Description = "Amazon Application Secret Key Description",
                      LastModified = "2013/06/01")]
        public string AmazonAPPSecretKeyDescription
        {
            get
            {
                return this["AmazonAPPSecretKeyDescription"];
            }
        }

        #endregion

        #region Twitter 

        [ResourceEntry("TwitterAPIKeyTitle",
                       Value = "Twitter API Key",
                       Description = "Twitter API Key Title",
                       LastModified = "2016/07/27")]
        public string TwitterAPIKeyTitle
        {
            get
            {
                return this["TwitterAPIKeyTitle"];
            }
        }

        [ResourceEntry("TwitterAPIKeyDescription",
                      Value = "Twitter API Key",
                      Description = "Twitter API Key Description",
                      LastModified = "2016/07/27")]
        public string TwitterAPIKeyDescription
        {
            get
            {
                return this["TwitterAPIKeyDescription"];
            }
        }

        [ResourceEntry("TwitterAPISecretTitle",
                        Value = "Twitter API Secret",
                        Description = "Twitter API Secret Title",
                        LastModified = "2016/07/27")]
        public string TwitterAPISecretTitle
        {
            get
            {
                return this["TwitterAPISecretTitle"];
            }
        }

        [ResourceEntry("TwitterAPISecretDescription",
                        Value = "Twitter API Secret",
                        Description = "Twitter API Secret Description",
                        LastModified = "2016/07/27")]
        public string TwitterAPISecretDescription
        {
            get
            {
                return this["TwitterAPISecretDescription"];
            }
        }

        #endregion

        #endregion

        #region UI

        [ResourceEntry("LandingPage",
                      Value = "Landing Page :",
                      Description = "Landing page label",
                      LastModified = "2013/06/01")]
        public string LandingPage
        {
            get
            {
                return this["LandingPage"];
            }
        }

        [ResourceEntry("LoginUsing",
                      Value = "Login using :",
                      Description = "Login using label",
                      LastModified = "2013/06/01")]
        public string LoginUsing
        {
            get
            {
                return this["LoginUsing"];
            }
        }
        
        #endregion
    }
}