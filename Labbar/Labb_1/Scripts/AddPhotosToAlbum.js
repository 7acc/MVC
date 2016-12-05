$("form#uploadimageform").submit(function (e) {
    e.preventDefault();

    var formData = new FormData($(this)[0]);

    var photoName = $("#photoName").val();

    var photodata = {
        Name: $("#photoName").val()
    };

    $.ajax({
        url: "/Photo/UploadPhoto/",
        type: "POST",
        data: formData,
        success: function (data) {

        },
        cache: false,
        processData: false,
        contentType: false

    }).success(function () {

        var model = {
            userId: $("#UserIdDiv").attr("data"),
            albumId: $("#albumIdDiv").attr("data")
        };

        $.ajax({
            url: "/Photo/GetExcludedPhotoSelector/",
            data: model,
            contentType: "application/html; charset=utf-8",
            type: "GET",
            dataType: "html"
        }).success(function (selectorData) {
            $("#PhotoSelector").html(selectorData);
        });
    });
});

$("#BackBtn").click(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/Album/ViewAlbum/",
        data: $("#albumIdDiv").attr("data"),
        contentType: "application/html; charset=utf-8",
        type: "GET",
        dataType: "html"
    }).success(function(backData) {
        $("div#AlbumContent").html(backData);
    });
});


