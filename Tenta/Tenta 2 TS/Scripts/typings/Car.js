var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Garage;
(function (Garage) {
    var Car = (function (_super) {
        __extends(Car, _super);
        function Car(roofType, manufacturer, regNr) {
            _super.call(this, manufacturer, regNr);
            this.RoofType = roofType;
        }
        return Car;
    }(Garage.Vehicle));
    Garage.Car = Car;
})(Garage || (Garage = {}));
