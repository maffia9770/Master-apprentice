<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher-pending.aspx.cs" Inherits="Master.teacher_pending" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Pending Quests</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">DVA231</a></li>
					<li><a href="#">DVA222</a></li>
					<li><a href="#">DVA123</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="login.aspx"><span class="glyphicon glyphicon-log-out">Logout</span></a></li>
                </ul>
            </div>
        </nav>
    </form>

<!-- Sidebar -->
	<div class="w3-sidebar w3-black w3-bar-block" style="width:15%">
		<h3 class="w3-bar-item">DVA231</h3>
		<h3 class="w3-bar-item"> - Pending Quests</h3>
		<a href="#" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey active">Main Quest 1</a>
		<a href="#" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">Main Quest 2</a>
		<a href="#" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">Main Quest 3</a>
	</div>

	<!-- Page Content -->
	<div style="margin-left:15%">

		<div class="w3-container w3-black w3-center">
		  <h1 class="w3-text-white">Main Quest 1 - Pending</h1>
		</div>

		<div class="w3-container">
			<p class="w3-text-white subtext">En tabell med studenter och info här, hämtad från databasen.</p>
			<p class="w3-text-white subtext">Tabellen ska innehålla info om namn på student, studentID, filen och Ja/Nej (två klickbara boxar).</p>
		</div>

	</div>

</body>
</html>
