<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RestaurantOwner.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
            table {
                margin:0 auto;
            }
            .auto-style1 {
                width: 160px;
                text-align:left;
            }
            .auto-style2 {
                width: 160px;
                font-weight:bold;
            }
            .auto-style3 {
                width: 160px;
                text-align:right;
            }
            .btn{
                font-weight:bold;
                font-size:16px;
                background-color: #59b300;
                color:white;
                border-radius: 5px;
                border: 1px solid #b3b3b3;
                width:480px;
                height:50px;
            }
            .auto-style2 a{
                color: #59b300;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" style="text-align:center;">
    <br />
    <br />
    <br />
        <asp:Label ID="lblError" runat="server"  Font-Size="Medium" ForeColor="Red" style="font-weight:bold"></asp:Label>
    <br />
    <br />
        <asp:Panel ID="Login" runat="server" GroupingText="Login" style="font-weight:500; font-size:40px;"></asp:Panel>
        <asp:TextBox ID="tb_Email" runat="server" Placeholder="Email*"  type="email" class="textbox" TextMode="Email"></asp:TextBox>
    <br />
        <asp:Label ID="lblEmail" runat="server" class="validation validation-360"></asp:Label>
    <br />
        <asp:TextBox ID="tb_Password" runat="server" Placeholder="Password*" class="textbox" TextMode="Password"></asp:TextBox>
    <br />
        <asp:Label ID="lblPassword" runat="server" class="validation validation-340"></asp:Label>
    <br />
        <asp:Button ID="btn_SignIn" runat="server" Text="SIGN IN" class="btn" OnClick="btn_SignIn_Click"/>
    <br />
        <table>
            <tr>
                <td class="auto-style2"><a class="form-text" href="UserRegister.aspx">Register</a><br /></td>
                <td class="auto-style3"><a class="form-text text-muted" href="UserForgetPassword.aspx">Forget Password?</a><br /></td>
            </tr>
        </table>
    <br />
    </form>
</asp:Content>
