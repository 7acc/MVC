﻿$(document).ready(function() {
    $("#addbtn").click(function(e) {
        e.preventDefault();

        var id = $("#idDiv").attr("data-model-id");      
        $.ajax({
            url: "/Album/AddPhotosToAlbum/",
            data: {albumId: id},
            contentType: "application/html; charset=utf-8",
            type: "GET",
            dataType: "html"
        }).success(function(result) {
            $("div#AlbumContent").html(result);
        });
    });
});