<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="character.aspx.cs" Inherits="Master.character" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Character</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.2.1.js"></script>
    <script src="scripts/jquery-3.2.1.intellisense.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json_parse.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json2.js"></script>
    <script type="text/javascript" src="Scripts/scripts.js"></script>
</head>
<body onload="Character(); GetSkills(); CharQuests();">
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <ul class="nav navbar-nav">
                    <li><a href="Home.aspx">Quest Log</a></li>
                    <li class="active"><a href="#">Character</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-out">Logout</span></a></li>
                </ul>
            </div>
        </nav>
    </form>

    <!-- Page Content -->
    <div id="Name" class="w3-container w3-black w3-center">
    </div>

    <div id="char-background">
        <img id="char-image" src="example-image.jpg" />
        <div id="Skills" class="w3-container">
            <p class="w3-text-white skills">Class: Computer mage</p>
            <p class="w3-text-white skills">Skills (DVA 231): </p>
        </div>
        <div id="Quests" class="w3-container">
        </div>
    </div>
</body>
</html>
