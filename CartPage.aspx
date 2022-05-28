<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="RestaurantOwner.CartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style7 {
            width: 42%;
            height: 131px;
            margin-left: 403px;
        }
        .auto-style9 {
            width: 196px;
            height: 91px;
            margin-left: 280px;
        }
        .auto-style10 {
            height: 91px;
            margin-left: 80px;
        }
        .auto-style11 {
            margin-left: 80px;
            height: 36px;
        }
        .auto-style12 {
            margin-left: 240px;
            height: 53px;
        }
        .auto-style13 {
            width: 196px;
            height: 53px;
            margin-left: 80px;
        }
        .auto-style14 {
            width: 196px;
            height: 30px;
        }
        .auto-style15 {
            height: 30px;
        }
        .auto-style16 {
            width: 196px;
            height: 36px;
        }
        .auto-style17 {
            margin-right: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 400px">
        &nbsp;&nbsp;&nbsp;
            <asp:GridView ID="gvCart" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gvCart_RowDeleting" DataKeyNames="ItemName" style="margin-left: 0px" Width="732px" CssClass="auto-style17">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name"/>
                    <asp:BoundField DataField="specialOrder" HeaderText="Special Orders" />
                    <asp:BoundField DataField="quantity" HeaderText="Qty"/>
                    <asp:BoundField DataField="price" HeaderText="Price"/>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                    <ControlStyle BackColor="Red" ForeColor="White" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <table class="auto-style7" border="1">
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label1" runat="server" Text="Enter Your Coupon Code: "></asp:Label>
                    <br />
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="263px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Height="29px" Text="Apply" Width="80px" OnClick="Button1_Click" />
                    <br />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    <asp:Label ID="Label4" runat="server" Text="Discount"></asp:Label>
                    : </td>
                <td class="auto-style15">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">
                    <asp:Label ID="Label6" runat="server" Text="Final Price:"></asp:Label>
                </td>
                <td class="auto-style11">
                    $
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" Height="30px" OnClick="ReturnToMenu_Click" Text="Return to Menu" Width="107px" />
                    </td>
                <td class="auto-style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="CheckOut" Height="38px" Width="89px" OnClick="CheckOut_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
