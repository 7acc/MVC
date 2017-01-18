using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Webb4_DAL.Models
{
    class AppartmentDataModel
    {
        public AppartmentDataModel()
        {
            this.Photos = new HashSet<AppartmentPhotoDataModel>();
        }

        public Guid AppartmentId { get; set; }
        public AdressDataModel AppartmentAdress { get; set; }
        public bool Avalible { get; set; }

        public DateTime SisstAnmälningsdag { get; set; }
        public DateTime VisningsDatum { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public virtual ICollection<AppartmentPhotoDataModel> Photos { get; set; } 
   
        
    }
}
