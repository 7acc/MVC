var app = angular.module("tentaApp", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "layOut.htm"
    })
    .when("/Tv1", {
        templateUrl: "Tv1.html"
    })
    .when("/Tv2", {
        templateUrl: "Tv2.html"
    })
    .when("/Tv3", {
        templateUrl: "Tv3.html"
    });
});