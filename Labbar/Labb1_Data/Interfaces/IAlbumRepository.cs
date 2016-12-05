using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Data.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<AlbumDatamodel> GetAll();
        void Add(AlbumDatamodel album);
        void Delete(Guid id);
        AlbumDatamodel GetById(Guid id);
        void SavenewAlbum(AlbumDatamodel newalbum, Guid[] photoIds, Guid userId);


        IEnumerable<PhotoDataModel> GetAlbumPhotos(Guid albumId);
        void SavePhotosToAlbum(Guid albumId, Guid[] photoIds);
    }
}
