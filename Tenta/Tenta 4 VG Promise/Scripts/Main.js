
$(document).ready(function () {

    var userArray = [
            {
                userName: "user1",
                password: "pass1"
            },
            {
                userName: "user2",
                password: "pass2"
            },
            {
                userName: "user3",
                password: "pass3"
            }
    ];


    var MsgDiv = $("#MsgDiv");

    var validateLogin = function () {
   

        var userNameFromInput = $("#UserNameInput").val();
        var PasswordFromInput = $("#PasswordInput").val();

        var def = $.Deferred();
        var matchFound = false;
        var matchingUser = {};

        $.each(userArray, function (key, user) {
            
            if (user.userName == userNameFromInput && user.password == PasswordFromInput) {
                matchFound = true;
                matchingUser = user;
               
            }
        });

        if (matchFound) {
            def.resolve(matchingUser);
        }
        else {
            def.reject("Login Not Successful");
        }
        return def.promise();



    };

    $("#LoginBtn").on('click', function () {
        alert("klick");
        validateLogin().then(
            function (user) {
                MsgDiv.html(user.userName + "successfully loged in")

            },
            function (error) {
                MsgDiv.html(error);
            });


    })
});
