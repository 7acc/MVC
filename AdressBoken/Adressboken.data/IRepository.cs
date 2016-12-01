using Adressboken.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressboken.data
{
    public interface IAdressRepository
    {
       void Add(Adress adress);
        void Delete(Guid adressID);
        IEnumerable<Adress> GetAll();
        Adress GetAdressById(Guid AdressID);

    }
}
