var Data;
(function (Data) {
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
    Data.MediaLibrary = MediaLibrary;
})(Data || (Data = {}));
