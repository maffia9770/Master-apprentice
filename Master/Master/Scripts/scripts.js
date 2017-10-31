function QuestAjax(Quest) {
    QuestText = $('#Q'+Quest).text();
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
            $("#Q" + Quest).addClass("active").siblings().removeClass("active");
        },
        error: function () {
            alert("ajaxerror");
        },
    });
}
function CheckQuests(UserID) {
    var i;
    var container = $(document.createElement('div'));

    $.ajax({
        type: 'POST',
        url: 'Home.aspx/CheckQuests',
        contentType: 'application/json; charset=utf-8',
        data: "{UserID: '" + UserID + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            for (i = 0; i < result.length; i++)
                $("#Qmain").append('<a runat="server" ID="Q'+i+'" onclick="QuestAjax('+i+')" class="w3-bar-item w3-button w3-hover-none w3-hover-text-grey">' + result[i].QuestName + '</a>');
            //$('#Qmain').after(container);
        },
        error: function () {
            alert("ajaxerror");
        },
    });
}
