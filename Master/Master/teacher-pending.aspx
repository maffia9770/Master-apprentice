<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher-pending.aspx.cs" Inherits="Master.teacher_pending" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Pending</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.2.1.js"></script>
    <script src="scripts/jquery-3.2.1.intellisense.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json_parse.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json2.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/scripts.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".CBOX").click(function (event) {
                if ($(this).attr("checked") == true) {
                    $(".CBOX").attr("checked", "");
                    $(this).attr("checked", "checked");
                } else {
                    $(this).attr("checked", "");
                }
            });
        });
    </script>
</head>
<body onload="CheckPending()">
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div>
                    <ul class="nav navbar-nav">
                        <li class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">DVA231
				<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="teacher-home.aspx">Quest Log</a></li>
                                <li><a href="teacher-students.aspx">Students</a></li>
                                <li class="active"><a href="#">Pending Quests</a></li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-out">Logout</span></a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- Sidebar -->
        <div id="Qmain" class="w3-sidebar w3-black w3-bar-block" style="width: 15%">
            <h3 id="Course" class="w3-bar-item">DVA231</h3>
        </div>

        <!-- Page Content -->
        <div style="margin-left: 15%">

            <div class="w3-container w3-black w3-center details" style="visibility: hidden">
                <h1 id="quest" class="w3-text-white">Main Quest 1</h1>
            </div>

            <div class="w3-container details" style="visibility: hidden">
                <h3 class="w3-text-white QuestT">Description</h3>
                <p id="desc" class="w3-text-white subtext">Info om questet här.</p>
                <h3 class="w3-text-white QuestT">Objectives</h3>
                <p id="obj" class="w3-text-white subtext">Info om objectives här.</p>
                <h3 class="w3-text-white QuestT">Rewards</h3>
                <p id="rew" class="w3-text-white subtext">Vilka lvlar man får här :)</p>
                <br />
                <br />
                <button type="button" class="btn btn-default w3-text-white w3-black" id="Download" onclick="window.open('Download.aspx');" >Download Attached File</button>
                <div class="w3-container" id="Skills" style="position:relative"></div>
                <br />
                <br />
                <asp:Button runat="server" ID="QuestSubmit" Text="Submit" OnClick="SubmitGrade_Click" CssClass="btn btn-default w3-text-white w3-black"/>
            </div>

        </div>
    </form>
</body>
</html>
