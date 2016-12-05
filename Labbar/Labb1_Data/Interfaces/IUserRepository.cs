using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserAccountDataModel> GetAll();
        void Add(UserAccountDataModel user);
        void Delete(Guid userId);
        UserAccountDataModel LoginUser(string email, string password);
        UserAccountDataModel GetProfile(Guid userId);
        UserAccountDataModel GetById(Guid userId);
        IEnumerable<AlbumDatamodel> GetUserAlbums(Guid userId);
    }
}
