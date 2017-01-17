module Garage {

    export class MC extends Vehicle {
        DeathTrap: boolean;

        constructor(deathTrap: boolean, manufacturer: string, regNr: string) {

            super(manufacturer, regNr);

            this.DeathTrap = deathTrap;

        }

    }
}