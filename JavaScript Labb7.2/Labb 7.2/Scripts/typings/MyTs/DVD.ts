module Data {

    export class DVD extends Product {

        public Title: string;
        public Director: string;

        constructor(Title: string, Director: string,
            Name: string, category: string, Price: number, ArticleNR: number) {

            super(Name, category, Price, ArticleNR)

            this.Title = Title;
            this.Director = Director;
        }
    }
}

