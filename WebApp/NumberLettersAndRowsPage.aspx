<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NumberLettersAndRowsPage.aspx.cs" Inherits="WebApp.NumberLettersAndRowsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="numberLettersLabel" Text="" runat="server"></asp:Label>
        </div>  
        <div>
            <asp:Label ID="numberRowsLabel" Text="" runat="server"></asp:Label>
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
