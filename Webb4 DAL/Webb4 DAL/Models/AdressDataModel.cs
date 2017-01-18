using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Webb4_DAL.Models
{
    class AdressDataModel
    {
        public Guid AdressID { get; set; }
        public string Street { get; set; }
        public string PostalNumber { get; set; }
        public string city { get; set; }

    }
}
