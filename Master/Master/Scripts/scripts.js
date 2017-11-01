var QuestStatus = 0;

function QuestAjax(Quest) {
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
    $("#quest").
    $("#desc").text(result[0].QuestDes);
    $("#obj").text(result[0].QuestObj);
    $("#rew").text(result[0].QuestRew);
    $(".details").css("visibility", "visible");
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
                $()
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
    var i;

    $.ajax({
        type: 'POST',
        url: 'character.aspx/Character',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function () {
            $("#Name").append('<h1>' + result.Name + '</h1>');
        },
        error: function () {
            alert("ajaxerror Character");
        }
    });
}