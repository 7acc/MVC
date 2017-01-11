/// <reference path="../angularjs/angular.d.ts" />
/// <reference path="../angularjs/angular-resource.d.ts" />
/// <reference path="library.ts" />
alert("running");
var app = angular.module("MediaApp", []);
app.controller("MediaController", function ($scope) {
    //let MediaElements: NodeListOf<Element> = document.getElementsByClassName("repeater"), element;  
    var Library = new Entitty.MediaLibrary();
    $scope.ListProducts = function () {
        $scope.Products = GetProducts();
    };
    $scope.ListBooks = function () {
        $scope.Books = Library.BookArray;
    };
    $scope.AddBook = function () {
    };
    function GetProducts() {
        var ProductArray = [];
        ProductArray = ProductArray.concat(Library.BookArray);
        ProductArray = ProductArray.concat(Library.DVDArray);
        ProductArray = ProductArray.concat(Library.GameArray);
        return ProductArray;
    }
});
