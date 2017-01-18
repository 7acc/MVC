module Garage {

    export class Car extends Vehicle {
        RoofType: string;
        
        constructor(roofType: string, manufacturer: string, regNr: string) {

            super(manufacturer, regNr);

            this.RoofType = roofType;
            
        }

    }
}