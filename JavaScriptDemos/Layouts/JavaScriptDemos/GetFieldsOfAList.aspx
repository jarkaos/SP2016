<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetFieldsOfAList.aspx.cs" Inherits="JavaScriptDemos.Layouts.JavaScriptDemos.GetFieldsOfAList" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>
    <script type="text/javascript">
        function getListOfFields() {
            var ctx = SP.ClientContext.get_current();
            var newTrainersList = ctx.get_web().get_lists().getByTitle('New Trainers');

            this.fields = newTrainersList.get_fields();

            this.fWorkPhone = fields.getByInternalNameOrTitle('WorkPhone');

            this.fWorkPhone.set_required(true);
            this.fWorkPhone.update();
            
            ctx.load(this.fields, "Include(Title,InternalName)");

            ctx.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure));
        }

        function onSuccess() {
            var ul = document.getElementById("allFields");
            var str = '';
            var fieldsEnum = this.fields.getEnumerator();

            while (fieldsEnum.moveNext()) {
                str = fieldsEnum.get_current().get_title() + '-' + fieldsEnum.get_current().get_internalName();
                var element = document.createElement('li');
                element.innerText = str;
                ul.appendChild(element);
            }
        }

        function onFailure(sender, args) {
            alert("Request failed: " + args.get_message() + "\n" + args.get_stackTrace());
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <input type="button" value="Get Field Of A List" onclick="getListOfFields()" />
    <ul id="allFields"></ul>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
