
$(document).ready(function () {



    $(".Deletelink").click(function (D) {
        D.preventDefault();
        alert("klick");
        alert($(this).attr("data-id"));

        var id = $(this).attr("data-id");
        alert(id);

        $.ajax({
            type: "POST",
            url: "/Adress/Delete",
            data: { AdressId: id },
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
})