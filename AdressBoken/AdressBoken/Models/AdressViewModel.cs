using Adressboken.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdressBoken.Models
{
    public class AdressViewModel
    {

        public Guid AdressId { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int PostalNumber { get; set; }
        public string Country { get; set; }
        public DateTime LastUpdated { get; set; }

        public AdressViewModel()
        {

        }

        public AdressViewModel(Adress adress)
        {
            AdressId = adress.AdressId;
            City = adress.City;
            StreetName = adress.StreetName;
            PostalNumber = adress.PostalNumber;
            Country = adress.Country;
            LastUpdated = adress.LastUpdated;
        }
        public Adress Transform()
        {
            var adress = new Adress
            {
                AdressId = this.AdressId,
                City = this.City,
                StreetName = this.StreetName,
                PostalNumber = this.PostalNumber,
                Country = this.Country,               
            };
            return adress;
        }
    }
}