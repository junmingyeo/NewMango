<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewCoupon.aspx.cs" Inherits="RestaurantOwner.ViewCoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Panel ID="vCoupon" runat="server" GroupingText="Current Coupons" style="font-weight:500; font-size:40px;">
        </asp:Panel>
        <br /><br />
        <div class="newcoupon">
            <table style="width: 350px; margin-left:auto; margin-right:auto; background-color:lightgray;">
                <tr>
                    <td>Enter Coupon Code:</td>
                    <td align="right">
                        <asp:TextBox ID="couponCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Enter Discount (%):</td>
                    <td align="right" class="auto-style1">
                        <asp:TextBox ID="discountPercentage" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="couponSubmitbt" runat="server" Text="Add Coupon" OnClick="couponSubmitbt_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br /><br />
        <div class="coupondiv">
            <asp:GridView ID="couponTableGV" runat="server" AutoGenerateColumns="False" DataKeyNames="couponCode" OnSelectedIndexChanged="couponTableGV_SelectedIndexChanged" Width="553px" BackColor="LightGray" BorderColor="Black" BorderStyle="Ridge" BorderWidth="2px" OnRowDeleting="couponTableGV_RowDeleting" OnRowEditing="couponTableGV_RowEditing" HorizontalAlign="Center" Height="181px" OnRowCancelingEdit="couponTableGV_RowCancelingEdit" OnRowUpdating="couponTableGV_RowUpdating" style="margin-top: 0px">
                <Columns>
                    <asp:BoundField DataField="couponCode" HeaderText="Coupon" SortExpression="couponCode" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="discountPercentage" HeaderText="Discount(%)" SortExpression="discountPercentage" >   
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" HeaderText="Edit Coupon" ShowEditButton="True">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete Coupon" ShowHeader="True" Text="Delete" >
                    <ControlStyle BackColor="#CC3300" ForeColor="White" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:ButtonField>
                </Columns>
                <HeaderStyle BackColor="Black" ForeColor="LightGray" />
            </asp:GridView>
            <br /> <br /> <br /> <br />
            <table style="margin:auto">
                <tr>
                    <td>
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
