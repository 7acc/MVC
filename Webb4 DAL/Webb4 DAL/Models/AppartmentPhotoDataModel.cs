using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webb4_DAL.Models
{
    class AppartmentPhotoDataModel
    {
        public Guid PhotoId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
