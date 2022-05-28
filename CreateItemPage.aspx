<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateItemPage.aspx.cs" Inherits="RestaurantOwner.CreateItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 211px;
        }
        .auto-style3 {
            height: 26px;
            width: 211px;
        }
        .auto-style4 {
            width: 442px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Panel ID="AddItem" runat="server" GroupingText="Add New Item" style="font-weight:500; font-size:40px;">
        </asp:Panel>
        <br /><br />
        <div>
            <table style="width: 420px; margin-left:auto; margin-right:auto; background-color:lightgray;">
                <tr>
                    <td class="auto-style2">
                        Item Name: 
                    </td>
                    <td>
                        <asp:TextBox ID="itemName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        Item Type:
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddl_ItemType" runat="server" class="textbox">
                            <asp:ListItem Selected="True" Value="Alacarte">Alacarte</asp:ListItem>
                            <asp:ListItem Value="Drinks">Drinks</asp:ListItem>
                            <asp:ListItem Value="Promotion">Promotion</asp:ListItem>
                            <asp:ListItem Value="Dessert">Dessert</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Price: 
                    </td>
                    <td>
                        <asp:TextBox ID="itemPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Image(.jpg/.png/.gif&nbsp; only):
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" style="height: 26px" />
                    </td>
                </tr>
                </table>
        </div>
        <br /><br />
        <table style="margin-left:auto; margin-right:auto; background-color:lightgray;" class="auto-style4">
            <tr>
                <td>Search by Item Name:</td>
                <td>
                    <asp:TextBox ID="searchbox" runat="server" style="text-align: center"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="searchbtn_Click" />
                </td>
                <td>
                    <asp:Button ID="resetbtn" runat="server" Text="Reset" OnClick="resetbtn_Click" />
                </td>
            </tr>
        </table>
        <br />
        <div>
            <asp:GridView ID="itemGV" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" HorizontalAlign="Center" Height="200px" OnRowCancelingEdit="itemGV_RowCancelingEdit" OnRowDeleting="itemGV_RowDeleting" OnRowEditing="itemGV_RowEditing" OnRowUpdating="itemGV_RowUpdating" Width="700px" BackColor="LightGray" BorderColor="Black" BorderStyle="Ridge" BorderWidth="2px">
                <Columns>
                    <asp:BoundField DataField="ItemID" HeaderText="Item ID" InsertVisible="False" SortExpression="ItemID" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ItemName" HeaderText="Item" SortExpression="Item" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Category" SortExpression="ItemType">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True">Alacarte</asp:ListItem>
                                <asp:ListItem>Drinks</asp:ListItem>
                                <asp:ListItem>Promotion</asp:ListItem>
                                <asp:ListItem>Desert</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemType") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemPrice" HeaderText="Price(S$)" SortExpression="ItemPrice" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Imagepath" runat="server" ImageUrl='<%# Eval("image") %>' Height="100px" Width="100px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Image ID="imgupload" runat="server" ImageUrl='<%# Eval("image") %>' Height="100px" Width="100px" />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" HeaderText="Edit Item" ShowEditButton="True">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" HeaderText="Delete Item" ShowDeleteButton="True">
                    <ControlStyle BackColor="#CC3300" ForeColor="White" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle BackColor="Black" ForeColor="LightGray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
            </asp:GridView>
            <br /><br /><br /><br />
            <table style="margin:auto">
                <tr>
                    <td>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" />
                    </td>
                 </tr>
             </table>
        </div>
    </form>
</asp:Content>
