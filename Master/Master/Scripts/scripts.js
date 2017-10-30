function QuestAjax(Quest) {
    Quest = $('#Q'+Quest).text();
    alert(Quest);
    $.ajax({
        type: 'POST',
        url: 'Home.aspx/DisplayQuest',
        contentType: 'application/json; charset=utf-8',
        data: "{Quest: '" + Quest + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d);
            //alert(result);
            $("#quest").text(result[0].QuestName);
            $("#desc").text(result[0].QuestDes);
            $("#obj").text(result[0].QuestObj);
            $("#rew").text(result[0].QuestRew);
            $(".details").css("visibility", "visible");



            /*//var result = JSON.stringify(data)
            var result = data;
            console.log();
            alert(result);
           // result = result.replace('[', '');
            //result = result.replace(']', '');
            alert(result);
            //result = JSON.parse(result);
            alert(result.QuestReward);
            alert(result.d[0].QuestReward)
            console.log(result.d);
           // alert("ajaxsuccess");
            alert(result.QuestName);
            $("#quest").text(result.QuestName);*/
        },
        error: function () {
            alert("ajaxerror");
        },
    });
}
function CheckQuests(Course) {
    var i;
    var container = $(document.createElement('div'));

    $.ajax({
        type: 'POST',
        url: 'Home.aspx/CheckQuests',
        contentType: 'application/json; charset=utf-8',
        data: "{Course: '" + Course + "'}",
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
