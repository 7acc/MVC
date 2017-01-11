module Entitty {

    export class Game extends Product {

        Title: string;
        Genre: string;
        developer: string;

        constructor(Title: string, Genre: string, Developer: string,
            Name: string, category: string, Price: number, ArticleNR: number) {

            super(Name, category, Price, ArticleNR)

            this.Title = Title;
            this.Genre = Genre;
            this.developer = Developer;
        }
    }
}