$(document).ready(function() {
    $("#PostCommentBtn").click(function(e) {
        e.preventDefault();
        alert("hej");
        alert("!!!");
        var commentTextBox = $("textarea#comment");
        var ID = $("#PhotoDiv").children("img").attr("id");

        var commentModel = {
            comment: commentTextBox.val()
        };

        $.ajax({
            url: "/Comments/PostComment/",
            data: {
                newComment: commentModel,
                photoId: ID
            },
            type: "POST",
            success: function(data) {

                $.ajax({
                    url: "/Comments/GetComments",
                    data: { imageId: ID },
                    contentType: "application/html; charset=utf-8",
                    type: "GET",
                    dataType: "html"

                }).success(function(result) {
                    $("div#CommentsDiv").html(result);
                    //alert($("#PhotoDiv").children("img").attr("id"));
                    commentTextBox.val("");

                });
            }
        });
    });
   
});

