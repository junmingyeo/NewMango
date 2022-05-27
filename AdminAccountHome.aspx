<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="AdminAccountHome.aspx.cs" Inherits="RestaurantOwner.AdminAccountHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn{
            font-weight:bold;
            font-size:16px;
            background-color: #59b300;
            color:white;
            border-radius: 5px;
            border: 1px solid #b3b3b3;
            width:350px;
            height:100px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <form runat="server" style="text-align:center;">
    <h1>Manage User Account</h1>
    <asp:Button runat="server" ID="createaccbtn" class="btn" OnClientClick="window.location.href='AddAccount.aspx'; return false;"
  Text="Create Account"></asp:Button>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <%--<asp:Button runat="server" ID="pwchange" class="btn" OnClientClick="window.location.href='PasswordChange.aspx'; return false;"
  Text="View Account"></asp:Button>--%>
    <asp:Button runat="server" ID="viewaccbtn" class="btn" OnClientClick="window.location.href='ViewAccount.aspx'; return false;"
  Text="View Account"></asp:Button>
    </form>
    <br />
    <br />
</asp:Content>
