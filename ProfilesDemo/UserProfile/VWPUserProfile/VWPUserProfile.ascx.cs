using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;

namespace UserProfile.VWPUserProfile
{
    [ToolboxItemAttribute(false)]
    public partial class VWPUserProfile : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VWPUserProfile()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpdateProperty_Click(object sender, EventArgs e)
        {
            UserProfileManager userProfileManager = new UserProfileManager(SPServiceContext.Current);
            UserProfile userProfile = userProfileManager.GetUserProfile(true);
            if (userProfile["WebSite"].Value.ToString() == "")
            {
                userProfile["WebSite"].Value = "http://http://portal.demo.local";
                SPContext.Current.Web.AllowUnsafeUpdates = true;
                userProfile.Commit();
                SPContext.Current.Web.AllowUnsafeUpdates = false;
            }

        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            string NA = "NA";
            lbProperties.Items.Clear();

            UserProfileManager userProfileManager = new UserProfileManager(SPServiceContext.Current);
            UserProfile userProfile = userProfileManager.GetUserProfile(true);

            ProfileSubtypePropertyManager pspm = userProfile.Properties;
            foreach (ProfileSubtypeProperty psp in pspm.PropertiesWithSection)
            {
                if (!psp.IsSection)
                {
                    if (userProfile[psp.Name].Value != null)
                    {
                        lbProperties.Items.Add(new ListItem(psp.DisplayName + " - " + userProfile[psp.Name].Value.ToString(), userProfile[psp.Name].Value.ToString()));
                    }
                    else
                    {
                        lbProperties.Items.Add(new ListItem(psp.DisplayName + " " + NA, psp.DisplayName + " " + NA));
                    }
                }
            }
        }
    }
}
