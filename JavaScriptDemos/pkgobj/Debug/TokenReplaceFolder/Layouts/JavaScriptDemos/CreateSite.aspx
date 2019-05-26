<%@ Assembly Name="JavaScriptDemos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=28905f0685c971b2" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateSite.aspx.cs" Inherits="JavaScriptDemos.Layouts.JavaScriptDemos.CreateSite" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>
    <script type="text/javascript">
        function createTimeSite() {
            var Description = "New Child Site";
            var Language = 1033;
            var Title = "New Child Site";
            var Url = "NewChildSite";
            var Permissions = false;
            var Template = "STS#0";

            var ctx = SP.ClientContext.get_current();
            this.web = ctx.get_web();

            var wci = new SP.WebCreationInformation();
            wci.set_description(Description);
            wci.set_language(Language);
            wci.set_title(Title);
            wci.set_url(Url);
            wci.set_useSamePermissionsAsParentSite(Permissions);
            wci.set_webTemplate(Template);

            this.newWeb = this.web.get_webs().add(wci);

            ctx.load(this.newWeb, 'Title', 'Description');

            ctx.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure));
        }

        function onSuccess(sender, args) {
            alert("Title: " + this.newWeb.get_title() + " Description: " + this.newWeb.get_description());
        }

        function onFailure(sender, args) {
            alert("Request failed: " + args.get_message() + "\n" + args.get_stackTrace());
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <input type="button" value="Create New Team Site" onclick="createTimeSite()" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
