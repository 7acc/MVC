using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb_1.Models
{
    public class Photo
    {
        public Guid PhotoID { get; set; }
        public string Name { get; set; }    
        public string Url { get; set; }
        public DateTime UploadedDate { get; set; }
 
        
    }

    public class PhotoComment
    {
    
    }
}