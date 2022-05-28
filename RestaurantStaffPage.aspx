<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RestaurantStaffPage.aspx.cs" Inherits="RestaurantOwner.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
            .btn {
                font-weight:bold;
                font-size:16px;
            background-color: #59b300;
            color:white;
            border-radius: 5px;
            border: 1px solid #b3b3b3;
            width:200px;
            height:60px;
            }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server" style="text-align:center;">
    <h1>Restaurant Staff Page</h1>
        <asp:Button class="btn" ID="Button7" runat="server" OnClick="Button7_Click" Text="Place Order" /> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Button class="btn" ID="Button8" runat="server" OnClick="Button8_Click" Text="View Orders" />
        <div class="auto-style1">
        </div>
        <br /> 
        <br /> 
    <a href="PasswordChange.aspx">Password change</a>
    <a href="EditProfile.aspx">Edit Profile</a>
    <a href="UserAccount.aspx">User Account</a>
    
    </form>
</asp:Content>
