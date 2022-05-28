<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="RestaurantOwner.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter your email address:</div>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="370px"></asp:TextBox>
        </p>
        Enter your Table Number:<br />
        <asp:TextBox ID="TextBox2" runat="server" Width="368px"></asp:TextBox>
        <br />
        <br />
        <br />
        <div style="margin-left: 160px">
            <asp:Button class="btn" ID="Button1" runat="server" Text="Next" OnClick="displayMenu" style="height: 26px" />
        </div>
    </form>
</body>
</html>