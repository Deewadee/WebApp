<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="section" >
            <div>
                <label>Введите букву:  </label>
                <asp:TextBox ID="inputTextBox" runat="server" />
            </div>
            <br />
            <div>
                <label>Работник </label>
                <asp:CheckBox ID="IsEmployeeCheckBox" runat="server" />
            </div>
            <br />
            <div>
                <asp:Button CssClass="button" ID="displayNamesBtn" runat="server" Text="" OnClick="DisplayPersonsPageOrEmployeesPage" />
            </div>
            <br />
            <div>
                <asp:Button CssClass="button" ID="displayCountLettersBtn" runat="server" Text="" OnClick="DisplayNumberLettersAndRowsPage" />
            </div>
            <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="inputTextBox" ValidationExpression="[A-Za-z]" 
                    ErrorMessage="Введено неверное количество символов, либо неправильный символ!" Display="Dynamic" ></asp:RegularExpressionValidator>
            </div>
        </section>
    </form>
</body>
</html>
