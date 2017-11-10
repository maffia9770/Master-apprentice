<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher-students.aspx.cs" Inherits="Master.teacher_students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master & Aprentice - Students</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.2.1.js"></script>
    <script src="scripts/jquery-3.2.1.intellisense.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json_parse.js"></script>
    <script type="text/html" src="https://github.com/douglascrockford/JSON-js/blob/master/json2.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/scripts.js"></script>
</head>
<body onload="GetStudents()">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div>
                    <ul class="nav navbar-nav">
                        <li class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">DVA231
				  <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="teacher-home.aspx">Quest Log</a></li>
                                <li class="active"><a href="#">Students</a></li>
                                <li><a href="teacher-pending.aspx">Pending Quests</a></li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="logout.aspx"><span class="glyphicon glyphicon-log-out">Logout</span></a></li>
                    </ul>
                </div>
            </div>
        </nav>

    <!-- Page Content -->
    <div class="w3-container w3-black w3-center">
        <h1 class="w3-text-white">DVA231 - Students</h1>
    </div>

    <div id="Students" class="w3-container">
    </div>

    <button type="button" class="btn" data-toggle="modal" data-target="#myModal">Add Student</button>

    <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <form runat="server" id="NewStudent">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Student</h4>
        </div>
        <div class="modal-body">
            <div class="form-group">
                <label for="usr">Name:</label>
                <input type="text" class="form-control" name="name" form="NewStudent" />
            </div>
            <div class="form-group">
                <label for="usr">UserID:</label>
                <input type="text" class="form-control" name="userid" form="NewStudent" />
            </div>
            <div class="form-group">
                <label for="pwd">Password:</label>
                <input type="text" class="form-control" name="pwd" form="NewStudent" />
            </div>
        </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            <asp:Button runat="server" ID="submitStudent" CssClass="btn btn-default" Text="Submit" OnClick="CreateStudent_Click"/>
        </div>
        </form>
      </div>
      
    </div>
    </div>
</body>
</html>

