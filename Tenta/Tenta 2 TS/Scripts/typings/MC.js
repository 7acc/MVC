var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Garage;
(function (Garage) {
    var MC = (function (_super) {
        __extends(MC, _super);
        function MC(deathTrap, manufacturer, regNr) {
            _super.call(this, manufacturer, regNr);
            this.DeathTrap = deathTrap;
        }
        return MC;
    }(Garage.Vehicle));
    Garage.MC = MC;
})(Garage || (Garage = {}));
