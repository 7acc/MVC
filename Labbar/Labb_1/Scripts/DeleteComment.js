$(document).ready(function() {
    $("#deleteComment").click(function(e) {
        e.preventDefault();
        //alert("Start?");

        var commentID = $(this).attr("data");
        var photoID = $(this).attr("photoData");
        $.ajax({
            url: "/Comments/DeleteComment",
            data: {
                commentid: commentID,
                photoId: photoID
            },
            type: "POST",
            beforeSend: function() {
                $("#Loader").fadeIn();
            },
            complete: function() {

                $("#Loader").fadeOut();

            }
        }).success(function() {
            //alert("GetStart");
            $.ajax({
                url: "/Comments/GetComments",
                data: { imageId: photoID },
                contentType: "application/html; charset=utf-8",
                type: "GET",
                dataType: "html"

            }).success(function(result) {
                $("div#CommentsDiv").html(result);
                //alert("done?");
            });
        });
    });
});