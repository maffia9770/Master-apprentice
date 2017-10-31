<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher-home.aspx.cs" Inherits="Master.teacher_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Quest Log: Master</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div>
                    <ul class="nav navbar-nav">
                        <li class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">DVA231
				  <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li class="active"><a href="#">Quest Log</a></li>
                                <li><a href="teacher-students.aspx">Students</a></li>
                                <li><a href="teacher-pending.aspx">Pending Quests</a></li>
                            </ul>
                        </li>
                        <li><a href="#">DVA222</a></li>
                        <li><a href="#">DVA123</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="login.aspx"><span class="glyphicon glyphicon-log-out">Logout</span></a></li>
                    </ul>
                </div>
            </div>
        </nav>
    </form>


    <!-- Sidebar -->
    <div class="w3-sidebar w3-black w3-bar-block" style="width: 15%">
        <h3 class="w3-bar-item">DVA231</h3>
        <a href="#" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey active">Main Quest 1</a>
        <a href="#" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">Main Quest 2</a>
        <a href="#" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">Main Quest 3</a>
        <a href="#" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">- Create New Quest</a>
    </div>

    <!-- Page Content -->
    <div style="margin-left: 15%">

        <div class="w3-container w3-black w3-center">
            <h1 class="w3-text-white">Main Quest 1</h1>
        </div>

        <div class="w3-container">
            <h3 class="w3-text-white">Description</h3>
            <p class="w3-text-white subtext">Info om questet här.</p>
            <h3 class="w3-text-white">Objectives</h3>
            <p class="w3-text-white subtext">Info om objectives här.</p>
            <h3 class="w3-text-white">Rewards</h3>
            <p class="w3-text-white subtext">Vilka lvlar man får här :)</p>
        </div>

    </div>
</body>
</html>
