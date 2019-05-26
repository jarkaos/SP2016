<%@ Assembly Name="JavaScriptDemos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=28905f0685c971b2" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRecordToAList.aspx.cs" Inherits="JavaScriptDemos.Layouts.JavaScriptDemos.AddRecordToAList" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>
    <script type="text/javascript">
        function addRecords() {
            var ctx = SP.ClientContext.get_current();
            var TrainersList = ctx.get_web().get_lists().getByTitle('ITAcademyTrainers');
            var lci = new SP.ListItemCreationInformation();

            this.listItem1 = TrainersList.addItem(lci);
            this.listItem2 = TrainersList.addItem(lci);
            this.listItem3 = TrainersList.addItem(lci);
            this.listItem4 = TrainersList.addItem(lci);

            listItem1.set_item('Title', 'Americo');
            listItem1.update();

            listItem2.set_item('Title', 'Hernan');
            listItem2.update();

            listItem3.set_item('Title', 'Perez');
            listItem3.update();

            listItem4.set_item('Title', 'Munizaga');
            listItem4.update();

            ctx.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure));
            

        }

        function onSuccess(sender, args) {
            alert("New Trainers has been added successfully.");
        }

        function onFailure(sender, args) {
            alert("Request failed: " + args.get_message() + "\n" + args.get_stackTrace());
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <input type="button" value="Add Records" onclick="addRecords()" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
