<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RestaurantManagerPage.aspx.cs" Inherits="RestaurantOwner.RestaurantManagerPage" %>
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
    <asp:Button runat="server" ID="createaccbtn" class="btn" OnClientClick="window.location.href='ViewCoupon.aspx'; return false;"
  Text="View Coupon"></asp:Button>
    <asp:Button runat="server" ID="pwchange" class="btn" OnClientClick="window.location.href='CreateItem.aspx'; return false;"
  Text="Create Menu Item"></asp:Button>
</asp:Content>