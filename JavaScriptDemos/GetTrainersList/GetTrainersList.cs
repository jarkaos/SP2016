using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace JavaScriptDemos.GetTrainersList
{
    [ToolboxItemAttribute(false)]
    public class GetTrainersList : WebPart
    {
        protected override void CreateChildControls()
        {
            var sl = new ScriptLink
            {
                ID = "SPScriptLink",
                Localizable = false,
                LoadAfterUI = true,
                Name = "sp.js"
            };
            this.Controls.Add(sl);

            var web = SPContext.Current.Web;
            var url = web.Url + "/MyJavaScriptModule/MyScript.js";
            this.Page.ClientScript.RegisterClientScriptInclude(
                "LoadDemo", ResolveClientUrl(url));
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.WriteLine("<input id='getTrainers' type='Button' value='Get Trainers' onclick='readRecords()' />");
            writer.WriteLine("<br />");
            writer.WriteLine("<br />");
            writer.WriteLine("<ul id='allTrainers'></ul>");
        }
    }
}
