$(document).ready(function() {
    $("form").submit(function(e) {
        e.preventDefault();


        var user = {
            Email: $("#Email").val(),
            Password: $("#Password").val()
        }
        $.ajax({
            url: "/Account/Login",
            type: "POST",
            data: user
        }).success(function () {
           alert("YEY!");
        });
    });
});
