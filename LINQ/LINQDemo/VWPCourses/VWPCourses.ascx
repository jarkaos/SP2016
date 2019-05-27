<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VWPCourses.ascx.cs" Inherits="LINQDemo.VWPCourses.VWPCourses" %>

Enter Course Category "Find Course"
<br />
<br />
<asp:TextBox ID="lbCategory" runat="server" Width="200px"></asp:TextBox>
<br />
<br />
<br />
<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Find Courses" />
<br />
<br />
<asp:Label ID="lblResultCount" runat="server"></asp:Label>
<br />
<p><asp:ListBox ID="lbCourses" runat="server" Rows="10" Width="100%"></asp:ListBox></p>