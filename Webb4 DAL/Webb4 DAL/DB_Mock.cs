using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Webb4_DAL.Models;

namespace Webb4_DAL
{
    class DB_Mock
    {
        public List<AppartmentDataModel> Apartments { get; set; } 
        public List<UserDataModel> Users { get; set; }
        public List<FeaturesDataModel> Features { get; set; }
        public List<AppartmentPhotoDataModel> Apartmentphotos { get; set; }
        public List<AdressDataModel> Adresses { get; set; }

        public DB_Mock()
        {
            this.Adresses = new List<AdressDataModel>();

            Adresses.Add(new AdressDataModel());
            Adresses.Add(new AdressDataModel());
            Adresses.Add(new AdressDataModel());
            Adresses.Add(new AdressDataModel());
            Adresses.Add(new AdressDataModel());


            this.Users = new List<UserDataModel>();

            Users.Add(new UserDataModel());
            Users.Add(new UserDataModel());
            Users.Add(new UserDataModel());
            Users.Add(new UserDataModel());
            Users.Add(new UserDataModel());

            this.Users = new List<UserDataModel>();
            this.Features = new List<FeaturesDataModel>();
            this.Apartmentphotos = new List<AppartmentPhotoDataModel>();


        }
         
    }
}
