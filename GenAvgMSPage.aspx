<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMain.Master" AutoEventWireup="true" CodeBehind="GenAvgMSPage.aspx.cs" Inherits="RestaurantOwner.GenerateMoneySpent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">

      function formatSearchTxt() {
            if ($('#<%=ddlSearchCaseLog.ClientID%> option:selected').val() == "D")
                    $('#<%=tbSearchCaseLog.ClientID%>').datepicker();
                else
                    $('#<%=tbSearchCaseLog.ClientID%>').datepicker("destroy");
        }

        function validateCaseLogDate(oSrc, args) {
            if ($('#<%=ddlSearchCaseLog.ClientID%> option:selected').val() != "D") {
                args.IsValid = true;
                return true;
            }

            var str = $('#<%=tbSearchCaseLog.ClientID%>').val();
        if (!isValidDate(str)) {
            args.IsValid = false;
            return false;
        }

        args.IsValid = true;
        return true;
        }

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-lg-12">
                <div class="form-group form-inline">
                    <asp:Label ID="lbSearchCaseLog" runat="server" Text="Search By:"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvSearchType" runat="server" ErrorMessage="Search criteria cannot be empty." ControlToValidate="ddlSearchCaseLog" Display="None"></asp:RequiredFieldValidator>

                    <asp:DropDownList ID="ddlSearchCaseLog" runat="server" CssClass="form-control" onChange="formatSearchTxt()">
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                        <asp:ListItem Value="D">Date</asp:ListItem>
                        <asp:ListItem Value="W">Week</asp:ListItem>
                        <asp:ListItem Value="M">Month</asp:ListItem>
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="rfvSearchTxt" runat="server" ErrorMessage="Search value cannot be empty." ControlToValidate="tbSearchCaseLog" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbSearchCaseLog" runat="server" placeholder="" CssClass="datepicker form-control" Width="350px"></asp:TextBox>
                    <asp:Button ID="tbSearch" runat="server" Text="Generate" />
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-info" OnClick="btnSearch_Click">
                        Search
                    </asp:LinkButton>

                    <asp:CustomValidator ID="cvDate" runat="server" Display="None" ControlToValidate="tbSearchCaseLog" ClientValidationFunction="validateCaseLogDate"
                        ErrorMessage="Invalid date" ValidateEmptyText="false"></asp:CustomValidator>

            </div>
        </div>
    </div>

    <br />

    <%--Table View for Money Spent--%>
    <asp:GridView ID="gvMoneySpent" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" runat="server">
                    <EmptyDataTemplate>
                        No available Reports.
                    </EmptyDataTemplate>

                    <Columns>
                        <%-- Date From --%>
                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lbDateFrom" runat="server" Text='<%# Bind("Date", "{0: dd MMMM yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- Date To --%>
                        <asp:TemplateField HeaderText="Date From" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lbDateTo" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <%-- Amount Spent --%>
                        <asp:TemplateField HeaderText="Amount Spent" ItemStyle-Width="150px">
                            <ItemTemplate>

                                <asp:Label ID="lbAmtSpent" runat="server" Text='<%# Bind("AmtSpent", "{0:C}") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Total Amount" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lbAmtTotal" runat="server" Text='<%# Bind("AmtTotal", "{0:C}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <%-- Number of Orders --%>
                        <asp:TemplateField HeaderText="Number of Orders" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lbOrdersCount" runat="server" Text='<%# Bind("NoOfOrders") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>

                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
</asp:Content>
