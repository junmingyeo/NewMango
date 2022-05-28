<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenuPage.aspx.cs" Inherits="RestaurantOwner.MainMenuPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>

        <style>
        .tab {
            display: inline-block;
            margin-left: 40px;
        }

    </style>
</head>

<body>
    <form id="form1" runat="server" style="text-align:center;">
        <h1>
            Mango Restaurant
            &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp;
            <asp:Button ID="Cart" runat="server" Text="View your order" OnClick="Cart_Click" />
        </h1>

        <table style="text-align:center;">
            <tr>
                <th style="text-align: center">
                    Our Menu
                </th>
            </tr>
            <tr>
                <td>
                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <a href="MenuItemPage.aspx?id=<%#Eval("ItemID") %>">
                                            <img alt="" height="100" width="100" src='<%# Eval("image") %>' /></a>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label><br />
                                        $<asp:Label ID="lblPrice" runat="server" Text='<%#Eval("ItemPrice") %>'></asp:Label><br />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </form>
</body>

</html>