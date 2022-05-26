<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="RestaurantOwner.AddAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
                    .btn{
                font-weight:bold;
                font-size:16px;
                background-color: #59b300;
                color:white;
                border-radius: 5px;
                border: 1px solid #b3b3b3;
            }

        .btn2{
            font-weight:bold;
            font-size:16px;
            background-color:  #ff3333;
            color:white;
            border-radius: 5px;
            border: 1px solid #b3b3b3;
        }
        
            .btn2{
    font-weight:bold;
    color:#59b300;
    border-radius: 5px;
    border: 2px solid #59b300;
    background-color:transparent;
}
.btn2:hover{
    background-color:#59b300;
    color:black;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="text-align:center;">
        <br /><br /><br />
              <asp:Panel ID="CreateAccount" runat="server" GroupingText="Create Account" style="font-weight:500; font-size:40px;">
        </asp:Panel>
        <asp:TextBox ID="tb_FirstName" runat="server" class="textbox" Placeholder="First Name*"></asp:TextBox>
        <br />
        <asp:Label ID="lblFirstName" runat="server" class="validation validation-330"></asp:Label>
        <br />
        <asp:TextBox ID="tb_LastName" runat="server" class="textbox" Placeholder="Last Name*" ></asp:TextBox>
        <br />
        <asp:Label ID="lblLastName" runat="server" class="validation validation-330"></asp:Label>
        <br />
        <asp:TextBox ID="tb_Email" runat="server" class="textbox" Placeholder="Email*" Type="Email"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" class="validation validation-360"></asp:Label>
        <br />
        <asp:TextBox ID="tb_Password" runat="server" class="textbox" Placeholder="Password*" Type="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" class="validation validation-330"></asp:Label>
        <br />
          <asp:TextBox ID="tb_ConfirmPassword" runat="server" Placeholder="Confirm Password*" class="textbox" TextMode="Password"></asp:TextBox><br />
                <asp:Label ID="lblConfirmPassword" runat="server" class="validation validation-285"></asp:Label><br />
        <asp:DropDownList ID="ddl_Role" runat="server">
            <asp:ListItem Value="">Please Select</asp:ListItem>  
            <asp:ListItem>Admin</asp:ListItem>  
            <asp:ListItem>Restaurant Staff</asp:ListItem>  
            <asp:ListItem>Restaurant Manager</asp:ListItem>  
            <asp:ListItem>Restaurant Owner</asp:ListItem>  
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblRole" runat="server" class="validation validation-330"></asp:Label>
        <br />
        <br />
    <asp:Button ID="btn_Create" runat="server" Text="ADD USER" Height="50px" Width="480px" class="btn"  OnClick="btn_Create_Click"/>
        <br />
    <asp:Button ID="btn_Cancel" runat="server" Text="CANCEL" Height="50px" Width="480px" class="btn btn2" OnClick="btn_Cancel_Click"/>
        <br />
        <br />
    </form>
</asp:Content>