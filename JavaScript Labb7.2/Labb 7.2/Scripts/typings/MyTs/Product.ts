module Data {
    export class Product {
        public Name: string;
        public Category: string;
        public Price: Number;
        public ArticleNR: number;

       public constructor(Name: string, Category: string, Price: number, ArticleNR: number) {
      
            this.Name = Name;
            this.Category = Category;
            this.Price = Price;
            this.ArticleNR = ArticleNR;
        }
    }
}