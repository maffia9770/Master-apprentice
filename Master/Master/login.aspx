<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Master.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="StyleSheet.css" />
    <title>Master-apprentice Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Top">
        </div>
        <div class="Mid">
            <div class="LoginBox">
                <asp:TextBox ID="Username" runat="server" CssClass="Tbox" placeholder="Username"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="Tbox" placeholder="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click" CssClass="btn" />
            </div>
        </div>
    </form>
</body>
</html>
