<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Master.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet.css" />
    <title></title>
    <style type="text/css">
        .Top {
            height: 18em;
        }
        .Mid {
            height: 10em;
        }
        .LoginBox {
            height: 10em;
            width: 20em;
            position: absolute;
            left: 40%;
        }
        .Tbox {
            width: 100%;
        }
        #Submit {
            position:absolute;
            left: 40%;
            width: 20%;
        }
    </style>
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
        <asp:TextBox ID="Password" runat="server" TextMode="Password"  CssClass="Tbox" placeholder="Password"></asp:TextBox>
                <br />
                <br />
        <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
