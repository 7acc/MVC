
$(document).ready(function () {



    $("#AddForm").submit(function (e) {
        alert("klick");
        e.preventDefault();

        var form = $(this).serialize();

        $.ajax({
            type: "POST",
            url: "/Adress/AddAdress",
            data: form,
            success: function (data) {
                alert("succses")
                $.ajax({
                    type: "GET",
                    url: "/Adress/GetAdresses",
                    success: function (result) {
                        alert(result);
                        $("#AdressesDiv").html(result);
                        alert("?");
                    }
                })
            }
        });
    })
    $(".UpdateLink").click(function (e) {
        e.preventDefault();
        alert("klick");
        alert($(this).attr("data-id"));

        var id = $(this).attr("data-id");
        alert(id);

        $.ajax({
            type: "GET",
            url: "/Adress/UpdateAdress",
            data: { AdressID: id },
            success: function (result) {
                alert("succs");
                $("#ManageDiv").html(result);

            }
        });
    });
});