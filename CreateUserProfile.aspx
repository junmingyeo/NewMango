<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="CreateUserProfile.aspx.cs" Inherits="RestaurantOwner.CreateUserProfile" %>
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
    <form id="form1" runat="server" style="text-align:center;">
        <br />
        Role:
        <asp:TextBox ID="UP_tb" placeholder="Role" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblUserProfile" runat="server" class="validation validation-330"></asp:Label>
        <br />
        <p>Grant User Access</p>
        <asp:DropDownList ID="Access_DDL" runat="server">
            <asp:ListItem Value="">Please Select</asp:ListItem>  
            <asp:ListItem>Yes</asp:ListItem>  
            <asp:ListItem>No</asp:ListItem>  
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblAccessDDL" runat="server" class="validation validation-330"></asp:Label>
        <br /><br />

        <asp:Button ID="AddUPBtn" class="btn" runat="server" Text="Add" OnClick="AddUPBtn_Click" />
    </form>
</asp:Content>
