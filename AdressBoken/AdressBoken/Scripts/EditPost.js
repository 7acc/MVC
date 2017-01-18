$(document).ready(function () {



    $("#UpdateForm").submit(function (u) {
        alert("klick");
        u.preventDefault();
        alert("updateklick");
        var updateform = $(this).serialize();
        var id = $("#adressId").attr("data-id");
        alert(id);

        $.ajax({
            type: "POST",
            url: "/Adress/UpdateAdress",
            data: updateform,
            success: function (data) {

                alert("succses")
                $.ajax({
                    type: "GET",
                    url: "/Adress/GetAdress",
                    data: { adressId: id },
                    success: function (result) {

                        alert(result);
                        $("#" + id).html(result);
                        alert("?");


                        $.ajax({
                            type: "GET",
                            url: "/Adress/showAddAdress",
                            success: function (result) {
                                alert("succs");
                                $("#ManageDiv").html(result);

                            }
                        });
                    }
                })
            }
        });
    })
});