<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Master.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet.css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 220px;
        }
        .auto-style2 {
            height: 334px;
            display: inline-block;
        }
        .newStyle1 {
            display: inline-block;
        }
        .newStyle2 {
            height: 10em;
            width: 20em;
            position: absolute;
            left: 40%;
            top: 252px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
    </div>
        <div class="auto-style2">
            <div class="newStyle2">
    
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
                <br />
                <br />

        <asp:TextBox ID="Password" runat="server" TextMode="Password" style="margin-bottom: 0px"></asp:TextBox>
    
        <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click" />
    
            </div>
        </div>
    </form>
</body>
</html>
