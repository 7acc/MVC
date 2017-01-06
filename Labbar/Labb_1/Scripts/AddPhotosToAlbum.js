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
        beforeSend: function () {
            $("#Loader").fadeIn();
        },
        complete: function () {

            $("#Loader").fadeOut();

        },
        data: formData,      
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


$("#AddPhotosBtn").click(function (e) {
    alert("addphotoklick");
    e.preventDefault();

    var PhotoIds = [];   
    var AlbumId = $("#albumIdDiv").attr("data");

    $(".photoCheck").each(function (index, box) {
       
        if (box.checked) {         
            alert("ischecked");
            alert(box.id);
            PhotoIds.push(box.id);
            alert("pushed");
        }
    });


    $.ajax({
        url: "/Album/AddPhotosToAlbum",
        type: "POST",
        data: {
            albumId: AlbumId,
            photoIds: PhotoIds
        },
        beforeSend: function() {

            $(".Loader2").fadeIn();
        }     
    }).success(function() {
        window.location.href = "/Album/ViewAlbum?albumId=" + $("#albumIdDiv").attr("data");
    });
});



