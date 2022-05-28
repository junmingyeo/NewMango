<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuItemPage.aspx.cs" Inherits="RestaurantOwner.MenuItemPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 160px;
        }

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
                                                    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>&nbsp; $
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
                    <asp:Label ID="Label1" runat="server" Text="Special Orders: "></asp:Label>
                    <asp:TextBox ID="specialOrders" runat="server" Height="60px" Width="529px"></asp:TextBox>
                    <br /> <br /><br /> <br /><br /> <br />
                    <table>
                        <tr>
                            <td class="auto-style1"> 
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Button class="btn" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" style="height: 26px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button class="btn" ID="btnBuy" runat="server" Text="Add to cart" OnClick="btnBuy_Click" style="height: 26px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"> 
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> 
    </form>
</body>
</html>