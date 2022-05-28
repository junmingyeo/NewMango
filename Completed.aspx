<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Completed.aspx.cs" Inherits="RestaurantOwner.Completed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 360px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            &nbsp;
            <table style="margin:auto">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Order Completed! Please wait for your food to arrive!"></asp:Label> <br />
                        <asp:Label ID="Label2" runat="server" Text="Click to return to menu"></asp:Label> <br />
                        <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>

