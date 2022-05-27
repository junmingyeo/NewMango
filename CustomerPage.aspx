<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="RestaurantOwner.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <div style="margin-left: 320px">
            <asp:Button ID="Button1" runat="server" Text="Next" OnClick="displayMenu" style="height: 26px" />
        </div>
    </form>
</body>
</html>