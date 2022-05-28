<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="ViewUserProfile.aspx.cs" Inherits="RestaurantOwner.ViewUserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
           text-align:center;
            margin: 0px auto;
        }
        .auto-style1 {
            text-align:center;
        }
        .btn{
            font-weight:bold;
            font-size:16px;
            background-color: #59b300;
            color:white;
            border-radius: 5px;
            border: 1px solid #b3b3b3;
            width:350px;
            height:100px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <br />
           <asp:Panel ID="ViewUser_Profile" runat="server" GroupingText="View User Profile" style="font-weight:500; font-size:40px;text-align:center;"></asp:Panel>
        <div class="auto-style1">
            <div>
                <center>
                    Search: <asp:TextBox ID="txtUPsearch" runat="server"></asp:TextBox> 
                    &nbsp;&nbsp; 
                    <asp:Button ID="searchUPbtn" runat="server" Text="Search" ShowHeaderWhenEmpty ="true" class="btn" EmptyDataText="No Records Found!" OnClick="searchUPbtn_Click" /> <br /> <br />
                </center>
            </div>
            <asp:Button ID="btn_AddUserProfile" runat="server" class="btn" Text="Add User Profile" OnClick="btn_AddUserProfile_Click" />
            <br />
            <br />
            <asp:Label ID="gvlbl" runat="server" class="gvLabel">Total User Profile: </asp:Label>
            <asp:Label ID="lbl_up_gvCount" runat="server" class="gvLabel"></asp:Label>
        &nbsp;<a href="ViewUserProfile.aspx">View All User Profiles</a></div>
        <br />
        <table class="w-100">
            <tr>
                <td><asp:GridView ID="gvUserProfile" runat="server" 
                    AutoGenerateColumns="False"
                    DataKeyNames="RoleID" 
                    Width="50%" 
                    AllowSorting="True" 
                    OnRowDeleting="suspendProfileBtn" 
                    OnRowCancelingEdit="gvUserProfile_RowCancelingEdit" 
                    OnRowEditing="gvUserProfile_RowEditing" 
                    OnRowUpdating="updateProfileBtn" 
                    ShowHeaderWhenEmpty="True"
                    HeaderStyle-CssClass="gridviewheader"
                    EmptyDataText="No Records Found"
                    EmptyDataRowStyle-Height="150px"
                    class="mygridview">
                    
                    <AlternatingRowStyle BackColor="#e6e6e6"/>
                    
            <Columns>
                <asp:BoundField DataField="RoleID" HeaderText="RoleID" />
                <asp:BoundField DataField="Role" HeaderText="Role" />
                <asp:BoundField DataField="FunctionAccess" HeaderText="Access Rights" />
                <%--<asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Role" HeaderText="Role" />--%>
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
                </td>
            </tr>
        </table>
        <br />
        <br />
    </form>
</asp:Content>
