
$(document).ready(function () {
    alert("hej1");
    $("form#Formen").submit(function (e) {
       
        e.preventDefault();
        $("#Loader").fadeIn();
        setTimeout(function() {
        var formData = new FormData($(this)[0]);


        $.ajax({
            url: "/Photo/UploadPhoto/",
            type: "POST",      
            data: formData,
            cache: false,
            processData: false,
            contentType: false

        }).success(function() {

            window.location.href = "/Gallery/index";
        });
        }, 1500);
    });
});