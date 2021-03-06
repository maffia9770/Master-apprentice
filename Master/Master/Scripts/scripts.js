﻿var QuestStatus = 0;

function QuestAjax(Quest) {
    $(".QSBUT").css("visibility", "hidden");
    QuestText = $('#Q' + Quest).text();
    var user = '-';
    if (QuestText.indexOf(user) > -1)
    {
        var index = QuestText.indexOf(user);
        var UserID = QuestText.substr(0, index);
        $.ajax({
            type: 'POST',
            url: 'teacher-pending.aspx/Save',
            contentType: 'application/json; charset=utf-8',
            data: "{User: '" + UserID + "'}",
            dataType: 'json',
            success: function (data) {
                Dropdown();
            },
            error: function () {
                alert("ajaxerror QuestAjaxBefore");
            }
        });
        QuestText = QuestText.substring(8);
    }
    $.ajax({
        type: 'POST',
        url: 'Home.aspx/DisplayQuest',
        contentType: 'application/json; charset=utf-8',
        data: "{Quest: '" + QuestText + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            $("#quest").text(result[0].QuestName);
            $("#desc").text(result[0].QuestDes);
            $("#obj").text(result[0].QuestObj);
            $("#rew").text(result[0].QuestRew);
            $(".details").css("visibility", "visible");
            $(".QuestActions").css("visibility", "hidden");
            if (QuestStatus == 0)
                $(".Accept").css("visibility", "visible");
            if (QuestStatus == 1)
                $(".Upload").css("visibility", "visible");
            $("#Q" + Quest).addClass("active").siblings().removeClass("active");
        },
        error: function () {
            alert("ajaxerror QuestAjax");
        }
    });
}
function NewQuest() {
    $("#quest").html('<input type="text" id="NewName" class="w3-text-white w3-black" placeholder="Quest" name="NewName" form="form1" >');
    $("#desc").html('<textarea rows="4" cols="50"" id="NewDesc" class="w3-text-white w3-black" name="NewDesc" form="form1">');
    $("#obj").html('<textarea rows="4" cols="50"" id="NewObj" class="w3-text-white w3-black" name="NewObj" form="form1">');
    $("#rew").html('<textarea rows="4" cols="50" id="NewRew" class="w3-text-white w3-black" name="NewRew" form="form1">');
    $("#rew").append('<br /><input type="checkbox" id="NewMain" CssClass="w3-text-white w3-black" value="1" name="Type" form="form1"> Main Quest');

    $("#NewName").addClass("NewQuest");
    $("#NewDesc").addClass("NewQuest");
    $("#NewObj").addClass("NewQuest");
    $("#NewRew").addClass("NewQuest");
    $("#NewMain").addClass("NewQuest");
    //$("#rew").append('<form action="teacher-home.aspx/CreateQuest" id="CreateQuest"><input type="submit" onserverclick class="btn btn-default NewQuest"></form>')
    $(".details").css("visibility", "visible");
    $(".QSBUT").css("visibility", "visible");
}
function CheckQuests(Status) {
    var i;
    var container = $(document.createElement('div'));
    QuestStatus = Status;

    $.ajax({
        type: 'POST',
        url: 'Home.aspx/CheckQuests',
        contentType: 'application/json; charset=utf-8',
        data: "{Status: '" + Status + "'}",
        dataType: 'json',
        success: function (data) {
            if ($("#NewQuest").length) {
            }
            else {
                $("#Qmain").empty();
                $("#Qmain").append('<h3 class="w3-bar-item">DVA231</h3>');
            }
            $(".details").css("visibility", "hidden");
            $(".QuestActions").css("visibility", "hidden");

            result = JSON.parse(data.d);
            if (result == null) {
                $("#Qmain").append('<p class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">No Quests Here</p>')
            }
            else {
                for (i = 0; i < result.length; i++)
                    $("#Qmain").append('<a runat="server" ID="Q' + i + '" onclick="QuestAjax(' + i + ')" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">' + result[i].QuestName + '</a>');
                //$('#Qmain').after(container);
            }
        },
        error: function () {
            alert("ajaxerror CheckQuests");
        }
    });
}
function Dropdown() {
    var i;
    var container = $(document.createElement('div'));
    var CourseID = "DVA231";

    $.ajax({
        type: 'POST',
        url: 'teacher-pending.aspx/Skills',
        contentType: 'application/json; charset=utf-8',
        data: "{CourseID: '" + CourseID + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            console.log(result)
            for (i = 0; i < result.length; i++)
            {
                $("#Skills").append('<textarea rows="1" cols="10"" id="Skill' + i + '" class="w3-text-white w3-black" name="Skill' + i + '" placeholder="' + result[i].Skill + '" onkeypress="return event.charCode >= 48 && event.charCode <= 57" form="form1">');
            }
                    
                //$('#Qmain').after(container);
        },
        error: function () {
            alert("ajaxerror Skills");
        }
    });
}
function CheckPending() {
    var i;
    var CourseID = "DVA231";

    $.ajax({
        type: 'POST',
        url: 'teacher-pending.aspx/CheckPending',
        contentType: 'application/json; charset=utf-8',
        data: "{CourseID: '" + CourseID + "'}",
        dataType: 'json',
        success: function (data) {
            if ($("#NewQuest").length) {
            }
            else {
                $("#Qmain").empty();
                $("#Qmain").append('<h3 class="w3-bar-item">DVA231</h3>');
            }
            $(".details").css("visibility", "hidden");
            $(".QuestActions").css("visibility", "hidden");
            
            result = JSON.parse(data.d);
            console.log(result);
            if (result == null) {
                $("#Qmain").append('<p class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">No Quests Here</p>')
            }
            else {
                for (i = 0; i < result.length; i++)
                    $("#Qmain").append('<a runat="server" ID="Q' + i + '" onclick="QuestAjax(' + i + ')" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">'+ result[i].UserID +"-"+ result[i].QuestID + '</a>');
                //$('#Qmain').after(container);
            }
        },
        error: function () {
            alert("ajaxerror CheckQuests");
        }
    });
}
function GetAllSkills(){
    var CourseID = "DVA231";
    $(".QSBUT").css("visibility", "hidden");
    QuestText = $('#Q' + Quest).text();
    $.ajax({
        type: 'POST',
        url: 'Home.aspx/DisplayQuest',
        contentType: 'application/json; charset=utf-8',
        data: "{Quest: '" + QuestText + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            $("#quest").text(result[0].QuestName);
            $("#desc").text(result[0].QuestDes);
            $("#obj").text(result[0].QuestObj);
            $("#rew").text(result[0].QuestRew);
            $(".details").css("visibility", "visible");
            $(".QuestActions").css("visibility", "hidden");
            if (QuestStatus == 0)
                $(".Accept").css("visibility", "visible");
            if (QuestStatus == 1)
                $(".Upload").css("visibility", "visible");
            $("#Q" + Quest).addClass("active").siblings().removeClass("active");
        },
        error: function () {
            alert("ajaxerror QuestAjax");
        }
    });
}
function SessionData() {
    var QuestID = $("#quest").text();
    $.ajax({
        type: 'POST',
        url: 'Home.aspx/SessionData',
        contentType: 'application/json; charset=utf-8',
        data: "{QuestID: '" + QuestID + "'}",
        dataType: 'json',
        success: function (data) {
        },
        error: function () {
            alert("ajaxerror SessionData");
        }
    });
}
function Character() {
    var QuestID = "Redacted";
    $.ajax({
        type: 'POST',
        url: 'character.aspx/Character',
        contentType: 'application/json; charset=utf-8',
        data: "{QuestID: '" + QuestID + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            $("#Name").append('<h1>' + result[0].Name + '</h1>');
        },
        error: function () {
            alert("ajaxerror Character");
        }
    });
}
function GetSkills() {
    var QuestID = "Redacted";
    var Levels;
    var i;
    var level3, level2, level1, points;
    var i;
    $.ajax({
        type: 'POST',
        url: 'character.aspx/GetSkills',
        contentType: 'application/json; charset=utf-8',
        data: "{QuestID: '" + QuestID + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            for(i = 0;i < result.length; i++)
            {
                $("#Skills").append('<p class="w3-text-white skills">' + result[i].Skill + ':</p>');
                level3 = parseInt(result[i].Level3);
                level2 = parseInt(result[i].Level2);
                level1 = parseInt(result[i].Level1);
                points = parseInt(result[i].Points);

                if(points >= level3)
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 3, You have reached the highest level. Well done!</p>');
                }
                else if (points >= level2)
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 2, You have '+ (level3 - points) +' points left to reach level 3.</p>');
                }
                else if (points >= level1)
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 1, You have ' + (level2 - points) + ' points left to reach level 2.</p>');
                }
                else
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 0, You have ' + (level1 - points) + ' points left to reach level 1.</p>');
                }
            }
        },
        error: function () {
            alert("ajaxerror GetSkills");
        }
    });
}
function CharQuests() {
    var QuestID = "REDACTED";
    var i;
    $.ajax({
        type: 'POST',
        url: 'character.aspx/CharQuests',
        contentType: 'application/json; charset=utf-8',
        data: "{QuestID: '" + QuestID + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            if (result == null)
                $("#Quests").append('<p class="w3-text-white quests"> You have no Main Quests left to complete. </p>');
            else {
                $("#Quests").append('<p class="w3-text-white quests"> You have yet to complete: </p>');
                for (i = 0; i < result.length; i++) {
                    $("#Quests").append('<p class="w3-text-white quests">' + result[i].QuestName + '.</p>');
                }
            }
        },
        error: function () {
            alert("ajaxerror CharQuests");
        }
    });
}
function GetStudents() {
	var i;
	var CourseID = "DVA231";

	$.ajax({
		type: 'POST',
		url: 'teacher-students.aspx/GetStudents',
		contentType: 'application/json; charset=utf-8',
		data: "{CourseID: '" + CourseID + "'}",
		dataType: 'json',
		success: function (data) {
			result = JSON.parse(data.d);
			console.log(data);
			if (result == null) {
				$("#Students").append('<p class="w3-text-white subtext>No Students</p>')
			}
			else {
			    for (i = 0; i < result.length; i++)
			    {
			        $("#Students").append('<p class="w3-text-white student" ID="' + result[i].UserID + '">' + result[i].Name + ', ' + result[i].UserID + ': </p>');
			        StudentQuests(result[i].UserID);
			    }
			}
		},
		error: function () {
			alert("ajaxerror CheckQuests");
		}
	});
}

function StudentQuests(UserID) {
    var UserID = UserID;
    $.ajax({
        type: 'POST',
        url: 'teacher-students.aspx/StudentQuests',
        contentType: 'application/json; charset=utf-8',
        data: "{UserID: '" + UserID + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            if (result == 0)
            {
                $("#" + UserID).append('<p class="w3-text-white student" ID="' + UserID + 'quests"> Main Quests Complete; </p>');
            }
            else
            {
                $("#" + UserID).append('<p class="w3-text-white student" ID="' + UserID + 'quests"> Main Quests Incomplete; </p>');
            }
            StudentSkills(UserID);
            
        },
        error: function () {
            alert("ajaxerror StudentQuests");
        }
    });
}

function StudentSkills(UserID) {
    var UserID = UserID;
    var i;
    var totlevel3 = 0, totlevel2 = 0, totlevel1 = 0;
    var level3, level2, level1, points;
    $.ajax({
        type: 'POST',
        url: 'teacher-students.aspx/StudentSkills',
        contentType: 'application/json; charset=utf-8',
        data: "{UserID: '" + UserID + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            for (i = 0;i < result.length;i++)
            {
                level3 = parseInt(result[i].Level3);
                level2 = parseInt(result[i].Level2);
                level1 = parseInt(result[i].Level1);
                points = parseInt(result[i].Points);
                if (points >= level3)
                    totlevel3++;
                if (points >= level2)
                    totlevel2++;
                if (points >= level1)
                    totlevel1++;
            }

            if (totlevel3 == result.length)
                $("#" + UserID + 'quests').append('<p class="w3-text-white student" ID="' + UserID + 'skills"> Has reached level 3 in all skills</p>');
            else if (totlevel2 == result.length)
                $("#" + UserID + 'quests').append('<p class="w3-text-white student" ID="' + UserID + 'skills"> Has reached level 2 in all skills</p>');
            else if (totlevel1 == result.length)
                $("#" + UserID + 'quests').append('<p class="w3-text-white student" ID="' + UserID + 'skills"> Has reached level 1 in all skills</p>');
            else
                $("#" + UserID + 'quests').append('<p class="w3-text-white student" ID="' + UserID + 'skills"> Has not reached level 1 in all skills</p>');

            $("#" + UserID + 'skills').append('<p class="w3-text-white"></p>');
        },
        error: function () {
            alert("ajaxerror StudentSkills");
        }
    });
}

function Logout() {
    var QuestID = "REDACTED";
    $.ajax({
        type: 'POST',
        url: 'login.aspx/Logout',
        contentType: 'application/json; charset=utf-8',
        data: "{QuestID: '" + QuestID + "'}",
        dataType: 'json',
        success: function (data) { },
        error: function () {
            alert("ajaxerror Logout");
        }
    });
}
