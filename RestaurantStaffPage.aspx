<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RestaurantStaffPage.aspx.cs" Inherits="RestaurantOwner.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <form id="form1" runat="server">
    <h1>Restaurant Staff Page</h1>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Place Order" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Orders" />
        <div class="auto-style1">
        </div>
        <br /> 
        <br /> 
    <a href="PasswordChange.aspx">Password change</a>
    <a href="EditProfile.aspx">Edit Profile</a>
    <a href="UserAccount.aspx">User Account</a>
    
    </form>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
