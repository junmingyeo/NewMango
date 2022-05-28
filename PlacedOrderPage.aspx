<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlacedOrderPage.aspx.cs" Inherits="RestaurantOwner.PlacedOrderPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 840px;
        }
        .btn {
            font-weight: bold;
            font-size: 16px;
            background-color: #59b300;
            color: white;
            border-radius: 5px;
            border: 1px solid #b3b3b3;
            width: 200px;
            height: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:GridView ID="gvCart" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ItemName,tblOrderID,served" style="margin-left: 0px" Width="732px" CssClass="auto-style17" OnRowDeleting="gvCart_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="tblOrderID" HeaderText="Order ID" />
                    <asp:BoundField DataField="tableNo" HeaderText="Table Number" />
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name"/>
                    <asp:BoundField DataField="specialOrder" HeaderText="Special Order"/>
                    <asp:BoundField DataField="quantity" HeaderText="Qty"/>
                    <asp:BoundField DataField="served" HeaderText="Status" />
                    <asp:CommandField ButtonType="Button" DeleteText="Served" ShowDeleteButton="True" />
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
                <br />
        </div>
        <div class="auto-style1">
            <asp:Button Class="btn" ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" />
        </div>
    </form>
</body>
</html>
