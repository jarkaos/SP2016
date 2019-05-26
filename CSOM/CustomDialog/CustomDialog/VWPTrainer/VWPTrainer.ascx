<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VWPTrainer.ascx.cs" Inherits="CustomDialog.VWPTrainer.VWPTrainer" %>

<script type="text/javascript">
    var dialogConfirm, openDialog;
    function showDialog() {
        var selectedId = document.getElementById('<%=lbTrainers.ClientID %>').value;
        var divDelete = document.getElementById("divDelete");
        divDelete.style.display = "block";
        dialogConfirm = {
            html: divDelete,
            title: 'Confirm Trainer Deletion',
            allowMaximize: true,
            showClose: true,
            width: 450,
            height: 200
        };
        openDialog = SP.UI.ModalDialog.showModalDialog(dialogConfirm);
    }

    function deleteTrainer() {
        this.TrainerId = document.getElementById('<%=lbTrainers.ClientID %>').value;
        var ctx = new SP.ClientContext();
        var trList = ctx.get_web().get_lists().getByTitle('ITAcademyTrainers');
        this.Trainer = trList.getItemById(TrainerId);
        Trainer.deleteObject();
        ctx.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailed));
    }

    function onSuccess() {
        alert("Trainer width ID " + TrainerId + " has been deleted");
        hideDialog();
    }

    function onFailed(sender, args) {
        alert("Error. Trainer could not be deleted " + "\n\n" + args.get_message() + "\n\n" + args.get_stackTrace());
        hideDialog();
    }

    function doCancel() {
        hideDialog();
    }

    function hideDialog() {
        openDialog.close();
        window.location.reload(true);
    }
</script>

<asp:ListBox ID="lbTrainers" runat="server" SelectionMode="Single" AutoPostBack="false" Rows="4" Width="100%" /> <br /> <br />
<input id="btnDelete" type="button" runat="server" onclick="javascript:showDialog()" value="Remove Selected Trainers" />

<div id="divDelete" style="display: none;">
    <table style="width:350px;" cellpadding="4" cellspacing="4">
        <tr>
            <td colspan="2">
                Are you sure of deleting this trainer?
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td align="center" style="width:150px">
                <input type="button" value="Yes" style="width:125px;" onclick="deleteTrainer()" />
            </td>
            <td align="center" style="width:150px">
                <input type="button" value="No" style="width:125px;" onclick="doCancel()" />
            </td>
        </tr>
    </table>
</div>