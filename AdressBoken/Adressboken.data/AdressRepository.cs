using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressboken.data.Models;

namespace Adressboken.data
{
    public class AdressRepository : IAdressRepository
    {
        public void Add(Adress NewAdress)
        {
            using (var ctx = new DataContext())
            {
                var theAdress = ctx.Adresses.FirstOrDefault(x => x.AdressId == NewAdress.AdressId);
                if (theAdress == null)
                {
                    ctx.Adresses.Add(NewAdress);
                    ctx.SaveChanges();
                }
                else
                {
                    theAdress.City = NewAdress.City;
                    theAdress.Country = NewAdress.Country;
                    theAdress.PostalNumber = NewAdress.PostalNumber;
                    theAdress.StreetName = NewAdress.StreetName;
                    theAdress.LastUpdated = NewAdress.LastUpdated;
                                    
                    ctx.Entry(theAdress).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public void Delete(Guid adressID)
        {
            using (var ctx = new DataContext())
            {
                var AdressToBeDeleted = ctx.Adresses.FirstOrDefault(x => x.AdressId == adressID);
                if (AdressToBeDeleted != null)
                {
                    ctx.Adresses.Remove(AdressToBeDeleted);
                    ctx.SaveChanges();
                }
            }
        }

        public Adress GetAdressById(Guid AdressID)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Adresses.Single(x => x.AdressId == AdressID);
            }
        }

        public IEnumerable<Adress> GetAll()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Adresses.ToList();
            }
        }
    }
}

   
