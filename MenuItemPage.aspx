<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuItemPage.aspx.cs" Inherits="RestaurantOwner.MenuItemPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3 align="center">
                Food Item
            </h3>
        </div>
        <table style="width: 50%; margin-left: auto; margin-right: auto; border:1px solid #ddd">
            <tr>
                <td>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>

                            <table style="width:100%; padding: 0; margin:0">
                                <tr>
                                    <td align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Image height="300" width="500" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>&nbsp;
                                                    <asp:Label ID="lblDBName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label><br />
                                                    <br />
                                                    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>&nbsp;
                                                    <asp:Label ID="lblDBPrice" runat="server" Text='<%# Eval("ItemPrice") %>'></asp:Label><br /><br />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <table>
                        <tr>
                            <td>
                                 <asp:Button ID="btnBuy" runat="server" Text="Add to cart" OnClick="btnBuy_Click" style="height: 26px" />
                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" style="height: 26px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> 
    </form>
</body>
</html>