using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Data.Interfaces
{
    public interface IPhotoRepository 
    {
        IEnumerable<PhotoDataModel> GetAll();
        void Add(PhotoDataModel Photo);
        void Delete(Guid id);
        PhotoDataModel GetById(Guid id);
        IEnumerable<PhotoDataModel> GetUserPhoto(Guid userId);
        IEnumerable<PhotoDataModel> GetRecentUploads(int count);
    }
}
