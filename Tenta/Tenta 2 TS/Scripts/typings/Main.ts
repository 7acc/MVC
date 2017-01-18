/// <reference path="jquery/jquery.d.ts" />
module Garage {

    alert("Running");
    let Cararray = [];
    let MCArray = [];

    let carDiv = document.getElementById('CarDiv');
    let MCDiv = $("#MCDiv");


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
    window.onload = function (): void {
     
        var carHtml = "";
        let MCHtml = "";

        PopulateArrays();

        for (let car of Cararray) {
            carHtml += ListCar(car);
        }
        for (let MC of MCArray) {
            MCHtml += ListMC(MC);
        }

        carDiv.innerHTML = carHtml;
        MCDiv.html(MCHtml);
    }
    
   function PopulateArrays() : void
    {
       Cararray.push(new Car("HardTop", "Alfa Romeo", "abc-123"));
       Cararray.push(new Car("Convertible","VW","def-456"));
       Cararray.push(new Car("ROOF?", "KIA", "ghj-789"));

       MCArray.push(new MC(true, "BMW", "123-abc"));
       MCArray.push(new MC(true, "MC.Smooth", "456-def"));
       MCArray.push(new MC(false, "BMW", "789-ghj"));

    }
   function ListCar(item: Car): string {

       return '<li>' + item.Manufacturer + " " + item.RoofType + " " + item.RegNr + '</li>'; 
   }
   function ListMC(item: MC): string {
       return '<li> deathTrap: ' +item.DeathTrap + " " + item.Manufacturer + " " + item.RegNr + '</li>'; 
   }



}


