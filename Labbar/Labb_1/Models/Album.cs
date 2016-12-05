using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Labb1_Data;

namespace Labb_1.Models
{
    public class Album
    {
        public Album()
        {
            this.Photos = new HashSet<Photo>();
        }
        [Key]
        public Guid AlbumId { get; set; }
        [Required(ErrorMessage = "Your album needs a name")]
        [MaxLength(30), MinLength(3)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public bool CanBeEdited { get; set; }

        public Album(AlbumDatamodel model)
        {           

            AlbumId = model.AlbumID;
            Name = model.Name;
            DateCreated = model.DateCreated;
            Photos = new List<Photo>();
        }
        public AlbumDatamodel Transform()
        {
            var albumDataModel = new AlbumDatamodel
            {


                AlbumID = this.AlbumId,
                Name = this.Name,
                DateCreated = this.DateCreated,
                Photos = this.Photos.Select(x => x.Transform()).ToList()
            };
            return albumDataModel;
        }
    }
}