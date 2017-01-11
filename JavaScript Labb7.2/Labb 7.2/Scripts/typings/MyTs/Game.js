var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Data;
(function (Data) {
    var Game = (function (_super) {
        __extends(Game, _super);
        function Game(Title, Genre, Developer, Name, category, Price, ArticleNR) {
            _super.call(this, Name, category, Price, ArticleNR);
            this.Title = Title;
            this.Genre = Genre;
            this.developer = Developer;
        }
        return Game;
    }(Data.Product));
    Data.Game = Game;
})(Data || (Data = {}));
