var Data;
(function (Data) {
    var Product = (function () {
        function Product(Name, Category, Price, ArticleNR) {
            this.Name = Name;
            this.Category = Category;
            this.Price = Price;
            this.ArticleNR = ArticleNR;
        }
        return Product;
    }());
    Data.Product = Product;
})(Data || (Data = {}));
