
var interval;
var ID = $("#PhotoDiv").children("img").attr("id");
$(function GetCommentsInterval() { 
    $.ajax({
        url: "/Comments/GetComments",
        data: { imageId: ID },
        contentType: "application/html; charset=utf-8",
        type: "GET",
        dataType: "html"

    }).success(function(result) {
        $("div#CommentsDiv").html(result);
        //alert($("#PhotoDiv").children("img").attr("id"));       
        interval = setTimeout(GetCommentsInterval, 10000);
    });
});
