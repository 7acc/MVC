$(document).ready(function() {
    $("#AlbumsBtn").click(function(e) {
        e.preventDefault();
      
        $.ajax({
            url: "/Gallery/ViewAllAlbums",            
            contentType: "application/html; charset=utf-8",
            type: "GET",
            dataType: "html"

        }).success(function (result) {       
            $("#AlbumContent").html(result);
        });
    });
    $("#CloseAlbums").click(function(e) {
        e.preventDefault();
        $("AlbumContent").html("")
    })
})