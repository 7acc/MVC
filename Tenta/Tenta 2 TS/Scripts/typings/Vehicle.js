var Garage;
(function (Garage) {
    var Vehicle = (function () {
        function Vehicle(manufacturer, regNR) {
            this.Manufacturer = manufacturer;
            this.RegNr = regNR;
        }
        return Vehicle;
    }());
    Garage.Vehicle = Vehicle;
})(Garage || (Garage = {}));
