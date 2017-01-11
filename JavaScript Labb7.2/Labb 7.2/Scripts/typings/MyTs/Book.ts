module Data{

    export class Book extends Product {

        public Title: string;
        public Author: string;
        
       public constructor(Title: string, Author: string,
           Name: string, Category: string, Price: number, ArticleNR: number) {
           
           super(Name, Category, Price, ArticleNR)
   
            this.Title = Title;
            this.Author = Author;

        }      
    }
}

