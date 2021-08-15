<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListEmployeesPage.aspx.cs" Inherits="WebApp.ListEmployeesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        
        <div>
            <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" AllowPaging="true" PageSize="30" Width="90px" OnPageIndexChanging="GridViewPageIndexChanging" >
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>
                    <asp:TemplateField HeaderText="FirstName">
                        <ItemTemplate>
                            <asp:LinkButton Text='<%# Eval("FirstName")%>' CommandArgument='<%# Eval("BusinessEntityID")%>' runat="server" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>           
                    <asp:TemplateField HeaderText="LastName">
                        <ItemTemplate>
                            <asp:LinkButton Text='<%# Eval("LastName")%>' CommandArgument='<%# Eval("BusinessEntityID")%>' runat="server" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="FirstName">
                        <ItemTemplate>
                            <asp:LinkButton Text='<%# Eval("JobTitle")%>' CommandArgument='<%# Eval("BusinessEntityID")%>' runat="server" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div>
            <asp:Label ID="messageLabel" Text="" runat="server"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="displayDefaultPageButton" Text="" runat="server" OnClick="DisplayDefaultPage" />
        </div>
        <div>
            <asp:Button ID="displayPreviousButton" Text="" runat="server" OnClick="DisplayPreviousPage" />
        </div>
    </form>
</body>
</html>
