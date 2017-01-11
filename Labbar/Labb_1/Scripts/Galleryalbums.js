$(document).ready(function() {
    $("#AlbumsBtn").click(function(e) {
        e.preventDefault();
      
        $.ajax({
            url: "/Gallery/ViewAllAlbums",            
            contentType: "application/html; charset=utf-8",
            type: "GET",
            beforeSend: function () {
                $("#Loader").fadeIn();
            },
            complete: function () {

                $("#Loader").fadeOut();

            },
            dataType: "html"

        }).success(function (result) {       
            $("#AlbumContent").html(result);
        });
    });
    $("#CloseAlbums").click(function(e) {
        e.preventDefault();
        $("AlbumContent").html("");
    });
})