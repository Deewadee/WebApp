<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonPage.aspx.cs" Inherits="WebApp.PersonPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                <Columns>
                    <asp:TemplateField HeaderText="BusinessEntityID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("BusinessEntityID")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PersonType">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PersonType")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NameStyle">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("NameStyle")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Title")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FirstName">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FirstName")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MiddleName">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("MiddleName")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LastName">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LastName")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Suffix">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Suffix")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EmailPromotion">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("EmailPromotion")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AdditionalContactInfo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("AdditionalContactInfo")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Demographics">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Demographics")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rowguid">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Rowguid")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ModifiedDate">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ModifiedDate")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>        
        <br />
        <div>
            <asp:Button ID="displayDefaultPage" Text="" runat="server" OnClick="DisplayDefaultPage" />
        </div>
        <div>
            <asp:Button ID="displayPreviousPage" Text="" runat="server" OnClick="DisplayPreviousPage" />
        </div>
    </form>
</body>
</html>
