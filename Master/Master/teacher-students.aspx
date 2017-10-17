<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher-students.aspx.cs" Inherits="Master.teacher_students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Students</title>
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

	<!-- Page Content -->
	<div class="w3-container w3-black w3-center">
	  <h1 class="w3-text-white">DVA231 - Students</h1>
	</div>

	<div class="w3-container">
	    <p class="w3-text-white subtext">En tabell med studenter och info här, hämtad från databasen.</p>
		<p class="w3-text-white subtext">Tabellen ska innehålla info om namn på student, studentID och betyg.</p>
	</div>

</body>
</html>

