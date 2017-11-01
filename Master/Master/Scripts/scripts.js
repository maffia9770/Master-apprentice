var QuestStatus = 0;

function QuestAjax(Quest) {
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
function NewQuest() {
    $("#quest").html('<input type="text" id="NewName" placeholder="Quest name" form="form1" >');
    $("#desc").html('<textarea rows="4" cols="50"" id="NewDesc" form="form1">');
    $("#obj").html('<textarea rows="4" cols="50"" id="NewObj" form="form1">');
    $("#rew").html('<textarea rows="4" cols="50" id="NewRew" form="form1">');

    $("#NewName").addClass("NewQuest");
    $("#NewDesc").addClass("NewQuest");
    $("#NewObj").addClass("NewQuest");
    $("#NewRew").addClass("NewQuest");
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
    var QuestID = "FGT";
    var Levels;
    var i;
    var level3, level2, level1, points;
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
                Levels = GetLevels(result[i].Skill);
                level3 = parseInt(Levels.Level3);
                level2 = parseInt(Levels.Level2);
                level1 = parseInt(Levels.Level1);
                points = parseInt(result[i].Points);
                if(points >= level3)
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 3, You have reached the highest level.</p>');
                }
                else if(points >= level2)
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 2, You have' + (level3 - points) +' points left to level 3.</p>');
                }
                else if(points >= level1)
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 1, You have' + (level2 - points) + ' points left to level 2.</p>');
                }
                else
                {
                    $("#Skills").append('<p class="w3-text-white skills">Level 0, You have' + (level1 - points) + ' points left to level 1.</p>');
                }
            }
        },
        error: function () {
            alert("ajaxerror GetSkills");
        }
    });
}
function GetLevels(Skill) {
    var Skill = Skill;
    $.ajax({
        type: 'POST',
        url: 'character.aspx/GetLevels',
        contentType: 'application/json; charset=utf-8',
        data: "{Skill: '" + Skill + "'}",
        dataType: 'json',
        success: function (data) {
        },
        error: function () {
            alert("ajaxerror GetLevels");
        }
    });
}