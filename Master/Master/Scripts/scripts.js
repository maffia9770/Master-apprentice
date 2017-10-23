function QuestAjax(Quest) {
    Quest = $('#'+Quest).text();
    alert(Quest);
    $.ajax({
        type: 'POST',
        url: 'Home.aspx/DisplayQuest',
        contentType: 'application/json; charset=utf-8',
        data: "{Quest: '" + Quest + "'}",
        dataType: 'json',
        success: function (data) {
            result = JSON.parse(data.d)
            //alert(result[0].QuestName);
            $("#quest").text(result[0].QuestName);
            $("#desc").text(result[0].QuestDes);
            $("#obj").text(result[0].QuestObj);
            $("#rew").text(result[0].QuestReward);




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
