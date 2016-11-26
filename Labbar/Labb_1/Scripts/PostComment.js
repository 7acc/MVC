$(document).ready(function () {
    $("#PostCommentBtn").click(function (e) {
        e.preventDefault();

        var commentModel = {
            comment: $("textarea#comment").val()
        };


        $.ajax({
            url: "/Comments/PostComment/",
            data: {
                newComment: commentModel,
                photoId: $("#PhotoDiv").children("img").attr("id")
            },
            type: "POST",
            success: function (data) { alert(data); }
        });
    });
});