var tenta = {};
tenta.productlistdiv = $("#productList");
tenta.FormDiv = $("#FormDiv");

tenta.pNameInput = $("#pName");
tenta.pIdInput = $("#pId");
tenta.pPriceInput = $("#pPrice");

tenta.ProductArray = [
    {   Name: "Product 1",
        Id:1,
        Price: 100
    },
    {
        Name: "Product 2",
        Id: 2,
        Price: 200
    },
    {
        Name: "Product 3",
        Id: 3,
        Price: 300
    },
    {
        Name: "Product 4",
        Id: 4,
        Price: 400
    },
    {
        Name: "Product 5",
        Id: 5,
        Price: 500
    },

];


$("#ListBtn").on('click', function () {
    alert("klick");
    tenta.FormDiv.hide();
    tenta.productlistdiv.html("");
    $.each(tenta.ProductArray, function (key, product) {
        tenta.productlistdiv.append('<li>' + product.Name + ' ' + product.Id + ' ' + product.Price + '</li>')

    })
});

$("#ShowFormBtn").on('click', function () {
    alert("klick");

    tenta.FormDiv.show();
});

$("#AddBtn").on('click', function () {
    var NewProduct = {
        Name: tenta.pNameInput.val(),
        Id: tenta.pIdInput.val(),
        Price: tenta.pPriceInput.val()
    }
    tenta.ProductArray.push(NewProduct);
})