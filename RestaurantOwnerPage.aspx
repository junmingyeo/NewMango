<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RestaurantOwnerPage.aspx.cs" Inherits="RestaurantOwner.Home" %>
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
    <h1>Owner</h1>
    <asp:Button runat="server" ID="genavgmoney" class="btn" OnClientClick="window.location.href='GenAvgMSPage.aspx'; return false;"
  Text="Generate Average Money Spending"></asp:Button>
    <asp:Button runat="server" ID="gentopsold" class="btn" OnClientClick="window.location.href='GenTopItemsPage.aspx'; return false;"
  Text="Generate Top Sold Item"></asp:Button>
         <asp:Button runat="server" ID="genfreqvisit" class="btn" OnClientClick="window.location.href='GenFreqVisitPage.aspx'; return false;"
  Text="Generate Frequency of Visits"></asp:Button>
    </form>
</asp:Content>