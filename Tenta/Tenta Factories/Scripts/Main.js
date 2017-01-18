var app = angular.module("tentaApp",[]).controller('TvController', function ($scope, tvFactory) {
    $scope.tvNavigate = tvFactory.Redirect(this.Attr("data"));
})
alert("running");
app.InfoArray = [
    { key: 1, info: "this is the info about tv1" },
{ key: 2, info: "this is the info about tv2" },
{ key: 3, info: "this is the info about tv3" }
];


app.factory("TvFactory", function ($scope) {

    var factory = {};
  
    factory.Redirect = function (id) {
        alert("klick");
        var object = infoArray.find(x => x.Key == id)
        $scope.TVINFO = object.info;
    }

    return factory;
});




    

