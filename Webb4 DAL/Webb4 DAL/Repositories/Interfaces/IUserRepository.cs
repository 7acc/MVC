using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webb4_DAL.Models;

namespace Webb4_DAL.Repositories.Interfaces
{
    interface IUserRepository
    {

        UserDataModel GetUserById();
        UserDataModel ValidateLogin(string userName, string passWord);
        void AddAppartmentToUserViewList(Guid appartmentId);
        void AddNewUser(UserDataModel newUser);
        void UpdateUserAdess(AdressDataModel newAdress);
        void DeleteUser(Guid UserId);


    }
}
