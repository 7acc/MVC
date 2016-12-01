using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressboken.data.Models
{
    public class Adress
    {
        public Guid AdressId { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int PostalNumber { get; set; }

        public string Country { get; set; }
        public DateTime LastUpdated { get; set; }
        
    }
   
}
