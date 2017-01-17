/// <reference path="jquery/jquery.d.ts" />
var Garage;
(function (Garage) {
    alert("Running");
    var Cararray = [];
    var MCArray = [];
    var carDiv = document.getElementById('CarDiv');
    var MCDiv = $("#MCDiv");
    //$(document).ready(function () {
    //    PopulateArrays();
    //    var carHtml = "";
    //    let MCHtml = "";
    //    alert("onload");
    //    for (let car of Cararray) {
    //        carHtml += ListCar(car);
    //    }
    //    for (let MC of MCArray) {
    //        MCHtml += ListMC(MC);
    //    }
    //    carDiv.html(carHtml);
    //    MCDiv.html(MCHtml);
    //});
    window.onload = function () {
        var carHtml = "";
        var MCHtml = "";
        PopulateArrays();
        for (var _i = 0, Cararray_1 = Cararray; _i < Cararray_1.length; _i++) {
            var car = Cararray_1[_i];
            carHtml += ListCar(car);
        }
        for (var _a = 0, MCArray_1 = MCArray; _a < MCArray_1.length; _a++) {
            var MC_1 = MCArray_1[_a];
            MCHtml += ListMC(MC_1);
        }
        carDiv.innerHTML = carHtml;
        MCDiv.html(MCHtml);
    };
    function PopulateArrays() {
        Cararray.push(new Garage.Car("HardTop", "Alfa Romeo", "abc-123"));
        Cararray.push(new Garage.Car("Convertible", "VW", "def-456"));
        Cararray.push(new Garage.Car("ROOF?", "KIA", "ghj-789"));
        MCArray.push(new Garage.MC(true, "BMW", "123-abc"));
        MCArray.push(new Garage.MC(true, "MC.Smooth", "456-def"));
        MCArray.push(new Garage.MC(false, "BMW", "789-ghj"));
    }
    function ListCar(item) {
        return '<li>' + item.Manufacturer + " " + item.RoofType + " " + item.RegNr + '</li>';
    }
    function ListMC(item) {
        return '<li> deathTrap: ' + item.DeathTrap + " " + item.Manufacturer + " " + item.RegNr + '</li>';
    }
})(Garage || (Garage = {}));
