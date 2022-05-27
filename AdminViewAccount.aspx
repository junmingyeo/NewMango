<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="AdminViewAccount.aspx.cs" Inherits="RestaurantOwner.AdminViewAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        table{
           text-align:center;
            margin: 0px auto;
        }
        .auto-style1 {
            text-align:center;
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
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <br />

           <asp:Panel ID="ViewAccount" runat="server" GroupingText="View Account" style="font-weight:500; font-size:40px;text-align:center;"></asp:Panel>
        <div class="auto-style1">
            <div>
                <center>
                    Search: <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox> 
                    &nbsp;&nbsp; 
                    <asp:Button ID="searchbtn" runat="server" Text="Search" ShowHeaderWhenEmpty ="true" class="btn" EmptyDataText="No Records Found!" OnClick="searchbtn_Click" /> <br />
                    <br />
                </center>
            </div>
            <asp:Button ID="btn_AddAccount" runat="server" class="btn" Text="Add Account" OnClick="btn_AddAccount_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" class="gvLabel">Total Available Account: </asp:Label>
            <asp:Label ID="lbl_gvCount" runat="server" class="gvLabel"></asp:Label>
        &nbsp;<a href="AdminViewAccount.aspx">View All Accounts</a></div>
        <br />
        <table class="w-100">
            <tr>
                <td><asp:GridView ID="gvAccount" runat="server" 
                    AutoGenerateColumns="False"
                    DataKeyNames="UserID" 
                    Width="50%" 
                    AllowSorting="True" 
                    OnRowDeleting="gvAccount_RowDeleting" 
                    OnRowCancelingEdit="gvAccount_RowCancelingEdit" 
                    OnRowEditing="gvAccount_RowEditing" 
                    OnRowUpdating="gvAccount_RowUpdating" 
                    ShowHeaderWhenEmpty="True"
                    HeaderStyle-CssClass="gridviewheader"
                    EmptyDataText="No Records Found"
                    EmptyDataRowStyle-Height="150px"
                    class="mygridview">
                    
                    <AlternatingRowStyle BackColor="#e6e6e6"/>
                    
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserID" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Role" HeaderText="Role" />
                <asp:CommandField ShowEditButton="True" EditText="<img style='height:20px; width:20px;' src='images/editicon.jpg'/>" />
                <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" 
             OnClientClick="javascript:return confirm('CONFIRM DELELTE?');">
            <img style='height:20px; width:20px;'src="images/deleteicon.jpg" alt="Delete" /></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
            </Columns>

<EmptyDataRowStyle Height="150px"></EmptyDataRowStyle>

<HeaderStyle></HeaderStyle>
                    <RowStyle CssClass="gridviewrow" />
        </asp:GridView>
                    <br />
                    <asp:Label ID="lblMessage" runat="server" CssClass="validation"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_back" runat="server" class="btn" Text="Back" OnClick="btn_Backbtn_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</asp:Content>
