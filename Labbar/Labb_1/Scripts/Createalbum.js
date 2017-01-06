



$(document).ready(function () {
    alert("ready");
    $("Form").submit(function (e) {
     
        alert("Klick");
       
        e.preventDefault();
        $("#Loader").fadeIn();

        setTimeout(function() {
            var PhotoIds = [];
            var Album = {
                Name: $("#Name").val()
        };
               

            $(".photoCheck").each(function (index, box) {

                if (box.checked) {
                 
                    PhotoIds.push(box.id);
                   
                }
            });


            $.ajax({
                url: "/Album/CreateAlbum",
                type: "POST",
                data: {
                    newalbum: Album,
                    photoIds: PhotoIds
                },
                beforeSend: function () {




                }
            }).success(function () {

                window.location.href = "/Profile/UserProfile";
            });
        }, 2000);
        
    });
});
