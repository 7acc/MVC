var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Data;
(function (Data) {
    var DVD = (function (_super) {
        __extends(DVD, _super);
        function DVD(Title, Director, Name, category, Price, ArticleNR) {
            _super.call(this, Name, category, Price, ArticleNR);
            this.Title = Title;
            this.Director = Director;
        }
        return DVD;
    }(Data.Product));
    Data.DVD = DVD;
})(Data || (Data = {}));
