using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb1_Data
{
    public class PhotoDataModel
    {
  
        public PhotoDataModel()
        {
            this.Comments = new HashSet<CommentDataModel>();
           this.Albums = new HashSet<AlbumDatamodel>();
        }
        [Key]
        public Guid PhotoID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid uploader { get; set; }
        public DateTime UploadedDate { get; set; }
        public virtual ICollection<CommentDataModel> Comments { get; set; }
        public virtual ICollection<AlbumDatamodel> Albums { get; set; }

        public void Update(PhotoDataModel photo)
        {
            Name = photo.Name;
        }
    }
}