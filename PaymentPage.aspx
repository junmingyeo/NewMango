<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="RestaurantOwner.PaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Card Number:&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="313px"></asp:TextBox>
        <p>
            Expiry Date:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" Width="55px"></asp:TextBox>
&nbsp;&nbsp; CVV:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <div style="margin-left: 330px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancel" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />

        </div>
    </form>
</body>
</html>
