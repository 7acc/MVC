var Entitty;
(function (Entitty) {
    var MediaLibrary = (function () {
        function MediaLibrary() {
            this.BookArray = [];
            this.DVDArray = [];
            this.GameArray = [];
        }
        ;
        MediaLibrary.prototype.AddBook = function (newBook) {
            this.BookArray.push(newBook);
        };
        return MediaLibrary;
    }());
    Entitty.MediaLibrary = MediaLibrary;
})(Entitty || (Entitty = {}));
