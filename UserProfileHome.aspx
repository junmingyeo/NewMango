<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="UserProfileHome.aspx.cs" Inherits="RestaurantOwner.UserProfileHome" %>
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
      <form runat="server" style="text-align:center;">
    <h1>Manage User Account</h1>
    <asp:Button runat="server" ID="createupbtn" class="btn" OnClientClick="window.location.href='CreateUserProfile.aspx'; return false;"
  Text="Create User Profile"></asp:Button>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" ID="viewupbtn" class="btn" OnClientClick="window.location.href='ViewUserProfile.aspx'; return false;"
  Text="View User Profile"></asp:Button>
    </form>
</asp:Content>