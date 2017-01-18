using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webb4_DAL.Models
{
    class FeaturesDataModel
    {

        [Key]
        [ForeignKey("FeaturesOfAppartment")]
        public Guid AppertmentID { get; set; }
        
        public bool Feature1 { get; set; }
        public bool Feature2 { get; set; }
        public bool Feature3 { get; set; }
        public bool Feature4 { get; set; }
        public bool Feature5 { get; set; }
        public bool Feature6 { get; set; }

        public AppartmentDataModel FeaturesOfAppartment { get; set; }
    }
}
