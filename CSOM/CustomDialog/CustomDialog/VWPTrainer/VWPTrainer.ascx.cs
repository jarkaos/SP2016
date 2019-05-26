using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace CustomDialog.VWPTrainer
{
    [ToolboxItemAttribute(false)]
    public partial class VWPTrainer : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VWPTrainer()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            SPList TrainersList = web.Lists["ITAcademyTrainers"];

            foreach (SPListItem Trainer in TrainersList.Items)
            {
                string title = Trainer["Title"].ToString();
                lbTrainers.Items.Add(new ListItem(title, Trainer.ID.ToString()));
            }
        }
    }
}
