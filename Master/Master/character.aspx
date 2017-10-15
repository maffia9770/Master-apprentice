<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="character.aspx.cs" Inherits="Master.character" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Character</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
	<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
		<nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <ul class="nav navbar-nav">
                    <li><a href="#">Quest Log</a></li>
                    <li class="active"><a href="#">Character</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#"><span class="glyphicon glyphicon-log-out">Logout</span></a></li>
                </ul>
            </div>
        </nav>
    </form>

	<!-- Page Content -->
	<div class="w3-container w3-black w3-center">
		<!-- Namn hämtat från databas -->
		<h1>Ragnar Stålnäve</h1>
	</div>

	<div class="w3-container">
		<img src="example-image.jpg" />
		<!-- Klass hämtad från databas -->
		<p class="w3-text-white">Class: Computer mage</p>
		<p class="w3-text-white">Skills: </p>
		<p class="w3-text-white">Ett table här med skills!</p>
	</div>
</body>
</html>