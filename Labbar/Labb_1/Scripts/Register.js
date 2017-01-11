
$(document).ready(function () {
    $("form").submit(function(e) {
        e.preventDefault();
       

        var account = {
            Name: $("#Name").val(),
            Email: $("#Email").val(),
            Password: $("#Password").val(),
            ConfirmPassword: $("#ConfirmPassword").val(),
            Admin: $("#Admin").val()

    }
       
        alert("formdata");
        $.ajax({
            url: "/Account/Register",
            type: "POST",
            data: account
        }).success(function() {
            $("#MSG").html("SUCCSES! YOU REGISTERED");
        });
    });
});
