using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb1_Data
{
    public class AlbumDatamodel
    {
        public AlbumDatamodel()
        {
            this.Photos = new HashSet<PhotoDataModel>();
        }
        [Key]
        public Guid AlbumID { get; set; }   
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<PhotoDataModel> Photos { get; set; }
        public Guid CreatedBy { get; set; }

        public void Update(AlbumDatamodel album)
        {
            Name = album.Name;
            Photos = album.Photos;
        }
    }
}