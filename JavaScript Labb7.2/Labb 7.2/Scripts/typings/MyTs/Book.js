var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Data;
(function (Data) {
    var Book = (function (_super) {
        __extends(Book, _super);
        function Book(Title, Author, Name, Category, Price, ArticleNR) {
            _super.call(this, Name, Category, Price, ArticleNR);
            this.Title = Title;
            this.Author = Author;
        }
        return Book;
    }(Data.Product));
    Data.Book = Book;
})(Data || (Data = {}));
