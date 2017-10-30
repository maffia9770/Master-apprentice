<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Master.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Quest Log</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.2.1.js"></script>
    <script src="scripts/jquery-3.2.1.intellisense.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json_parse.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json2.js"></script>
    <script type="text/javascript" src="Scripts/scripts.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".nav a").filter(function () { return this.href == location.href }).parent().addClass("active").siblings().removeClass("active")
            $(".nav a").click(function () {
                $(this).parent().addClass("active").siblings().removeClass("active")
            })
        })
    </script>

</head>
<body onload="CheckQuests('DVA231')">
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Quest Log</a></li>
                    <li><a href="character.aspx">Character</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="login.aspx"><span class="glyphicon glyphicon-log-out">Logout</span></a></li>
                </ul>
            </div>
        </nav>
        <nav class="navbar navbar-inverse subnav">
            <div class="container-fluid subnav">
                <ul class="nav navbar-nav subnav">
                    	<li class="active"><a href="#">Available</a></li>
                    	<li><a href="#">Active</a></li>
			            <li><a href="#">Completed</a></li>
			            <li><a href="#">Failed</a></li>
                </ul>
            </div>
        </nav>
    </form>

    
	<!-- Sidebar -->
	<div id="Qmain" class="w3-sidebar w3-black w3-bar-block" style="width:15%">
		<h3 class="w3-bar-item">DVA231</h3>
	</div>

	<!-- Page Content -->
	<div style="margin-left:15%">

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
	</div>

	</div>
</body>
</html>
