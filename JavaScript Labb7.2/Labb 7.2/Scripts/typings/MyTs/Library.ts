module Entitty {

    export class MediaLibrary {

        BookArray: Book[];
        DVDArray: DVD[];
        GameArray: Game[];

       


        constructor() {

            this.BookArray = [];
            this.DVDArray = [];
            this.GameArray = [];
            
              
        };


        AddBook(newBook: Book) {
            this.BookArray.push(newBook);        
        }




    }
}