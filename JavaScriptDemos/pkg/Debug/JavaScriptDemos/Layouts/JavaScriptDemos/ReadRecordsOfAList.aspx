<%@ Assembly Name="JavaScriptDemos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=28905f0685c971b2" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadRecordsOfAList.aspx.cs" Inherits="JavaScriptDemos.Layouts.JavaScriptDemos.ReadRecordsOfAList" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>
    <script type="text/javascript">
        function readRecords() {
            var ctx = SP.ClientContext.get_current();
            var TrainersList = ctx.get_web().get_lists().getByTitle('New Trainers');

            var camlQuery = new SP.CamlQuery();

            camlQuery.set_viewXml('<View><Query><Where><BeginsWith><FieldRef Name=\'Title\'/>' +
                '<Value Type=\'Text\'>M</Value></BeginsWith></Where></Query></View>');

            this.allTrainers = TrainersList.getItems(camlQuery);

            ctx.load(allTrainers);

            ctx.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure));
        }

        function onSuccess() {
            var ul = document.getElementById("allTrainers");
            var str = '';
            var TrainersListItemEnum = this.allTrainers.getEnumerator();

            while (TrainersListItemEnum.moveNext()) {
                var oListItem = TrainersListItemEnum.get_current();

                str = 'ID: ' + oListItem.get_id() + ' Title: ' + oListItem.get_item('Title');

                var element = document.createElement('li');
                element.innerText = str;
                ul.appendChild(element);
            }
        }

        function onFailure(sender, args) {
            alert("Error: " + args.get_message() + "\n" + args.get_stackTrace());
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <input type="button" value="Get Trainers List" onclick="readRecords()" />
    <ul id="allTrainers"></ul>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
